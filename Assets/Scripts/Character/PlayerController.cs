using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls actions of player
public class PlayerController : MonoBehaviour
{
    // create references to different map interactions
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    public LayerMask grassLayer;
    public event Action OnEncounter;

    // keep track of player movement and input
    private bool isMoving;
    private Vector2 input;

    // reference to unity animator
    private CharacterAnimator animator;

    private void Awake()
    {
        animator = GetComponent<CharacterAnimator>();
    }

    // movement system
    public void HandleUpdate()
    {
        // if player isnt actively moving 
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // if there is x input, cancel y input (erases diagonal movement)
            if(input.x != 0) input.y =0;


            if (input != Vector2.zero)
            {
                animator.MoveX = input.x;
                animator.MoveY = input.y;
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // if target passes walkable check
                if (IsWalkable(targetPos))
                    // initiate movement function
                    StartCoroutine(Move(targetPos));
            }
        }

        // tell animator character is moving
        animator.IsMoving = isMoving;

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.MoveX, animator.MoveY);
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    // movement function that checks for grass/battle at the end
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;

        CheckForBattle();
    }

    // checks if terrain is walkable
    private bool IsWalkable(Vector3 targetPos)
    {
        // if target position collides with solidObjectsLayer
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            // IsWalkable() returns false
            return false;
        }
        return true;
    }

    // function for initiating battle in grass
    private void CheckForBattle()
    {
        // if player is colliding with grass tile during movement
        if (Physics2D.OverlapCircle(transform.position, 0.1f, grassLayer) != null)
        {
            // 10% chance to initialize combat
            if (UnityEngine.Random.Range(1, 101) <= 10)
            {
                animator.IsMoving = false;
                OnEncounter();
            }
        }
    }
}
