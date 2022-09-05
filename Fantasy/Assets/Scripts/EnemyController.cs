﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    protected Rigidbody2D rb;
    protected Animator anim;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnHit(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");
        if(health <= 0)
        {
            speed = 0;
            rb.velocity = Vector2.zero;
            anim.SetTrigger("death");
            //here comes the death animation
            Destroy(this.gameObject,.5f);
        }
    }

    public void Death()
    {
       speed = 0;
       rb.velocity = Vector2.zero;
       anim.SetTrigger("death");
       Destroy(this.gameObject,.5f);
    }
}
