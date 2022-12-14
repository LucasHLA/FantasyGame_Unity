using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser_Enemy : EnemyController
{

    [SerializeField] private float maxVision;
    [SerializeField] private float stopDistance;
    [SerializeField] private bool isFront;
    [SerializeField] private bool isRight;

    [SerializeField] private Transform point;
    [SerializeField] private Transform behindPoint;

    private Vector2 direction;
    protected override void Start()
    {
        base.Start();

        if (!isRight)
        {
            transform.eulerAngles = new Vector2(0, 0);
            direction = Vector2.left;

        }

        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            direction = Vector2.right;

        } 
    }

    private void FixedUpdate()
    {
        GetPlayer();
        Movement();
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
                    hit.transform.GetComponent<PlayerController>().OnHit(2);
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
            if (!isRight)
            {
                transform.eulerAngles = new Vector2(0, 0);
                direction = Vector2.left;
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
                direction = Vector2.right;
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(point.position, direction * maxVision);
        Gizmos.DrawRay(behindPoint.position, -direction * maxVision);
    }

}
