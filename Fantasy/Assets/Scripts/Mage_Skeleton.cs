using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Skeleton : EnemyController
{
    [SerializeField] private float maxVision;
    [SerializeField] private float stopDistance;
    [SerializeField] private bool isFront;
    [SerializeField] private bool isRight;

    private bool isShooting;

    [SerializeField] private Transform point;
    [SerializeField] private Transform behindPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject healingPrefab;
    [SerializeField] private Transform firePoint;

    private Vector2 direction;

    protected override void Start()
    {
        base.Start();
        if (isRight)
        {
            transform.eulerAngles = new Vector2(0, 0);
            direction = Vector2.right;

        }

        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            direction = Vector2.left;

        }
    }

    private void FixedUpdate()
    {
        GetPlayer();
        Movement();
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    IEnumerator ThrowingMagic()
    {
        yield return new WaitForSeconds(1f);
        Shoot();
    }
    IEnumerator OnShooting()
    {
        yield return new WaitForSeconds(2f);
        isShooting = false;
    }

    private void GetPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, direction, maxVision);

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Player"))
            {
                anim.SetInteger("state", 1);
                isFront = true;
                float distance = Vector2.Distance(transform.position, hit.transform.position);

                if (distance <= stopDistance)
                {
                    isFront = false;
                    rb.velocity = Vector2.zero;
                    anim.SetInteger("state", 2);
                    if (!isShooting)
                    {
                        isShooting = true;
                        StartCoroutine(ThrowingMagic());
                        StartCoroutine(OnShooting());
                    }
                }
            }
        }


        RaycastHit2D behindHit = Physics2D.Raycast(behindPoint.position, -direction, maxVision);

        if (behindHit.collider != null)
        {
            if (behindHit.transform.CompareTag("Player"))
            {
                isRight = !isRight;
                isFront = true;
            }

        }

        if (hit.collider == null && behindHit.collider == null)
        {
            anim.SetInteger("state", 0);
            isFront = false;
        }

    }

    private void Movement()
    {
        if (isFront)
        {
            anim.SetInteger("state", 1);
            if (isRight)
            {
                transform.eulerAngles = new Vector2(0, 0);
                direction = Vector2.right;
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
                direction = Vector2.left;
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }


    }

    public void MageOnHit(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");
        if (health <= 0)
        {
            MageDeath();
        }
    }

    private void MageDeath()
    {
        GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("death");
        speed = 0;
        rb.velocity = Vector2.zero;
        Instantiate(healingPrefab, transform.position, healingPrefab.transform.rotation);
        Destroy(this.gameObject, 2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(point.position, direction * maxVision);
        Gizmos.DrawRay(behindPoint.position, -direction * maxVision);
    }

}