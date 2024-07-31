using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   bool canAttack = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (canAttack)
            {
                hit.Damage();
                canAttack=false;
                StartCoroutine(AttackCooldown());
            }

        }
    }

    IEnumerator AttackCooldown(){
        yield return new WaitForSeconds(.5f);
        canAttack=true;
    }
}
