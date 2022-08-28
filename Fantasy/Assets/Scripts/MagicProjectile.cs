using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    [SerializeField] private Transform firePoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject, 1f);
            //enemy hit method here
        }

    }
}
