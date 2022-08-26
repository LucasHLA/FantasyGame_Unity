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
    

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        col2D = GetComponent<Collider2D>();

    }

    protected virtual void Update()
    {
        anim.SetInteger("state", (int)state);
        Movement();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        state = State.walking;

        if (horizontal > 0)
        {
            tr.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(horizontal < 0)
        {
            tr.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Mathf.Abs(rb.velocity.x) <= 0)
        {
            state = State.idle;
        }

        if(Input.GetButtonDown("Jump") && col2D.IsTouchingLayers(ground))
        {
            Jump();
        }
    }

    void Jump()
    {
        state = State.jumping;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);   
    }
}

  
