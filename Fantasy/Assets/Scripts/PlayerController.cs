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
    protected enum State {idle, walking, jumping, falling}
    [SerializeField] protected State state;  

    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    protected bool isJumping;
    protected bool isAttacking;
    protected bool isRunning;
    private float recoverTime;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        col2D = GetComponent<Collider2D>();

    }

    protected virtual void Update()
    {
        Jump();
        
    }

    protected virtual void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //se nao pressionar nada, retorna 0. Se pressionar direita, retorna 1. Se for esquerda, retorna -1.
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

    void OnHit(int dmg)
    {
        recoverTime += Time.deltaTime;

        if(recoverTime >= 2f)
        {
            health -= dmg;
            anim.SetTrigger("hit");

            recoverTime = 0f;
        }
        
        if(health <= 0)
        {
            speed = 0;
            rb.velocity = Vector2.zero;
            /*add death animation here
            ganme over come here as well*/
        }

    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}


  
