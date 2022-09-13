using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    // reference health object in game
    [SerializeField] GameObject health;

    // lowers HPbar ui to match health
    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    // creates hp animation effect
    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = health.transform.localScale.x;
        float changeAmt = curHp - newHp;

        //while current hp is larger than resulting hp
        while (curHp - newHp > Mathf.Epsilon)
        {
            // subtract from current health a little at a time, rinse, repeat
            curHp -= changeAmt * Time.deltaTime;
            health.transform.localScale = new Vector3(curHp, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3(newHp, 1f);
    }
}
