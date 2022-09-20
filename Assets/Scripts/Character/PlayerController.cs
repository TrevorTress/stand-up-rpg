using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls actions of player
public class PlayerController : MonoBehaviour
{
    public event Action OnEncounter;
    private Vector2 input;

    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    // movement system
    public void HandleUpdate()
    {
        // if player isnt actively moving 
        if (!character.IsMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // if there is x input, cancel y input (erases diagonal movement)
            if(input.x != 0) input.y =0;


            if (input != Vector2.zero)
            {
                StartCoroutine(character.Move(input, CheckForBattle));
            }
        }

        character.HandleUpdate();

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, GameLayers.i.InteractableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact(transform);
        }
    }

    // function for initiating battle in grass
    private void CheckForBattle()
    {
        // if player is colliding with grass tile during movement
        if (Physics2D.OverlapCircle(transform.position, 0.1f, GameLayers.i.GrassLayer) != null)
        {
            // 10% chance to initialize combat
            if (UnityEngine.Random.Range(1, 101) <= 10)
            {
                character.Animator.IsMoving = false;
                OnEncounter();
            }
        }
    }
}
