using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    [SerializeField] private Transform firePoint;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.right*speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Red"))
        {
            anim.SetTrigger("hit");
            collision.gameObject.GetComponent<EnemyController>().OnHit(1);
            Destroy(gameObject, 0.2f);
            //enemy hit method here
        }

    }
}
