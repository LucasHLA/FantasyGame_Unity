﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{
    private Collider2D col2D;
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpLength;
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool facingLeft;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform leftPoint;
    private bool isJumping;


    protected override void Start()
    {
        base.Start();
        col2D = GetComponent<Collider2D>();
        facingLeft = true;
        rightCap = rightPoint.position.x;
        leftCap = leftPoint.position.x;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Move();
        Fall();
    }

    void Fall()
    {
        if (isJumping)
        {
            if(rb.velocity.y < 1f)
            {
                isJumping = false;
                anim.SetInteger("state", 3);
            }
        }
        if (col2D.IsTouchingLayers(ground) && !isJumping)
        {
            anim.SetInteger("state", 0);
        }
    }

    IEnumerator JumpRight()
    {
        yield return new WaitForSeconds(1f);
        anim.SetInteger("state", 2);
        rb.velocity = new Vector2(jumpLength, jumpHeight);
        
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(1f);
        anim.SetInteger("state", 2);
        rb.velocity = new Vector2(-jumpLength, jumpHeight);

    }

    void Move()
    {
        if (!facingLeft)
        {
            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.eulerAngles = new Vector3(0,180f,0);
                }

                if (col2D.IsTouchingLayers(ground) && !isJumping)
                {
                    anim.SetInteger("state", 1);
                    StartCoroutine(Jump());
                    isJumping = true;
                }

            }
            else
            {
                facingLeft = true;

            }
        }

        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.eulerAngles = new Vector3(0, 0f, 0);
                }

                if (col2D.IsTouchingLayers(ground) && !isJumping)
                {
                    //jump
                    anim.SetInteger("state", 1);
                    StartCoroutine(JumpRight());
                    isJumping = true;
                }

            }
            else
            {
                facingLeft = false;
            }
        }
    }

}


