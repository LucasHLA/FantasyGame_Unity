using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    [SerializeField] private Transform firePoint;
    [SerializeField] protected PlayerAudio audio;
    private Animator anim;
    private int blueSlimeHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.right*speed;
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Red"))
        {
            anim.SetTrigger("hit");
            //audio.PlaySFX(audio.slimeHit);
            collision.gameObject.GetComponent<EnemyController>().OnHit(1);
            Destroy(this.gameObject,0.19f);
            
        }
        if (collision.CompareTag("Blue"))
        {
            anim.SetTrigger("hit");
            collision.gameObject.GetComponent<EnemyController>().OnHit(1);
            Destroy(this.gameObject, 0.19f);
            
        }

        if (collision.CompareTag("Mage"))
        {
            anim.SetTrigger("hit");
            collision.gameObject.GetComponent<Mage_Skeleton>().MageOnHit(1);
            Destroy(this.gameObject, 0.19f);
        }


    }
}
