using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Player player;

    [SerializeField] protected GameObject diamondPrefabs;

    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;

    protected bool isHit = false;
    protected bool isDead = false;

    protected BoxCollider2D boxCollider;
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        if (!isDead)
        {
            Movement();
        }
    }
    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);

        if (distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            transform.localScale = Vector3.one;

        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}





















