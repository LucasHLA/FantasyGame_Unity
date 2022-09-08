using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Skeleton : EnemyController
{


    [SerializeField] private bool mustPatrol;
    [SerializeField] private bool mustFlip;
    [SerializeField] private Transform detector;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Collider2D wallDetection;

    private bool isRight;

    protected override void Start()
    {
        base.Start();
        mustPatrol = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(detector.position, 0.1f, ground);
            isRight = !isRight;
        }
    }


    private void Patrol()
    {
        if (mustFlip || wallDetection.IsTouchingLayers(ground))
        {
            Flip();
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void Flip()
    {
        mustPatrol = false;
        if (isRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            speed *= -1;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            speed *= -1;
        }
        
        
        mustPatrol = true;
        
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detector.position, 0.1f);
    }

}
