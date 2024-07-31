using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    Animator anim;
    Animator swordAnim;

    [SerializeField] float playerSpeed = 5f;
    public float jumpForce = 5f; // Zıplama kuvveti
    public Transform groundCheck; // Zemini kontrol etmek için kullanılan transform
    public float groundCheckRadius = 0.2f; // Zemini kontrol etmek için kullanılan çemberin yarıçapı
    public LayerMask groundLayer; // Zemin katmanını belirlemek için kullanılan mask

    private bool isGrounded;

    public int Health { get; set; }

    public int diamondAmount;

    private bool isDead = false;

    [SerializeField] GameObject[] lifeUnits;
    [SerializeField] GameObject deathPanel;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        swordAnim = transform.GetChild(2).GetComponent<Animator>();
    }
    private void Start()
    {
        Health = 4;
        deathPanel.SetActive(false);
    }
    void Update()
    {
        if (!isDead)
        {
            PlayerMovement();
            PlayerJump();
            PlayerAttack();
        }

    }


    void PlayerMovement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);
        anim.SetFloat("Run", MathF.Abs(rb.velocity.x));
        PlayerFlip();

    }

    void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }
    }

    void PlayerFlip()
    {
        if (rb.velocity.x >= 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            anim.SetTrigger("Attack");
            swordAnim.SetTrigger("SwordAnimation");
        }
    }

    public void Damage()
    {
        Health--;

        switch (Health)
        {
            case 3:
                lifeUnits[3].SetActive(false);
                break;
            case 2:
                lifeUnits[3].SetActive(false);
                lifeUnits[2].SetActive(false);
                break;
            case 1:
                lifeUnits[3].SetActive(false);
                lifeUnits[2].SetActive(false);
                lifeUnits[1].SetActive(false);
                break;
            case 0:
                isDead = true;
                deathPanel.SetActive(true);
                anim.SetTrigger("Death");
                lifeUnits[3].SetActive(false);
                lifeUnits[2].SetActive(false);
                lifeUnits[1].SetActive(false);
                lifeUnits[0].SetActive(false);
                break;
        }

    }

    public void AddGems(int amount)
    {
        diamondAmount += amount;
        UIManager.instance.UpdateGemCount(diamondAmount);
    }
}
