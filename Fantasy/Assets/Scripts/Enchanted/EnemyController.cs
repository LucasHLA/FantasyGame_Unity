using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected  GameObject healingPrefab;
    [SerializeField] protected EnemyAudio enemyAudio;
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
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
       speed = 0;
       rb.velocity = Vector2.zero;
       anim.SetTrigger("death");
        Instantiate(healingPrefab, transform.position, healingPrefab.transform.rotation);
        Destroy(this.gameObject,.5f);
    }

    
}
