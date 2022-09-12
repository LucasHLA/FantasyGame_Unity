using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    [SerializeField] private Transform firePoint;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("hit");
            collision.gameObject.GetComponent<PlayerController>().RangeOnHit(3);
            Destroy(gameObject, 0.1f);
        }

    }
}
