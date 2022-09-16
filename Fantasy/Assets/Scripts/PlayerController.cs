using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;
    protected Transform tr;
    protected Collider2D col2D;
    [SerializeField] protected LayerMask ground;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float hurtForce;
    [SerializeField] private GameObject fairy;
    [SerializeField] private HealthBar healthBar;
    public int health;
    public int maxHealth;
    protected bool isJumping;
    protected bool isAttacking;
    protected bool isRunning;
    private float recoverTime;
    private float gameOverTime;


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        col2D = GetComponent<Collider2D>();
        maxHealth = 10;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    protected virtual void Update()
    {
        healthBar.SetHealth(health);
        Jump();
    }

    protected virtual void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (horizontal > 0)
        {
            if (!isJumping && !isAttacking)
            {
                anim.SetInteger("state", 1);
                isRunning = true;
            }

            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (horizontal < 0)
        {
            if (!isJumping && !isAttacking)
            {
                anim.SetInteger("state", 1);
                isRunning = true;
            }

            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (horizontal == 0 && !isJumping && !isAttacking)
        {
            anim.SetInteger("state", 0);
            isRunning = false;
        }

    }

    protected virtual void Jump()
    {
        if (col2D.IsTouchingLayers(ground))
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetInteger("state", 2);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
            if (isJumping)
            {
                if (rb.velocity.y < 1f)
                {
                    anim.SetInteger("state", 3);
                }
            }
        }

    }

    public void OnHit(int dmg)
    {
        recoverTime += Time.deltaTime;
        if (recoverTime >= 1f)
        {
            health -= dmg;
            anim.SetTrigger("hit");
            healthBar.SetHealth(health);
            recoverTime = 0f;
            if (health <= 0)
            {
                Death();
            }
        }
    }

    public void RangeOnHit(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");

        if(health <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        anim.SetTrigger("death");
        speed = 0;
        rb.velocity = Vector2.zero;
        Destroy(this.gameObject, .5f);
        Destroy(fairy, .5f);
        GameController.instance.ShowGameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("Red"))
        {

            health--;
            anim.SetTrigger("hit");


            if (health <= 0)
            {
                Death();

            }
        }

    }
}


  
