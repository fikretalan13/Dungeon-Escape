using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] GameObject acidEffect;
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {

    }
    public void Damage()
    {
        if (isDead)
            return;
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefabs, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            Destroy(this.gameObject, 3);
        }
    }

    public override void Movement()
    {
        //sit still
    }

    public void Attack()
    {
        Instantiate(acidEffect, transform.position, Quaternion.identity);
    }




}
