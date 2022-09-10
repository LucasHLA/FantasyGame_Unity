using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fairy : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private float stopDistance;
    private Transform target;
    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            anim.SetInteger("state", 1);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            anim.SetInteger("state", 0);
        }

        Flip();
        
    }

    void Flip()
    {
        if(transform.position.x < target.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(transform.position.x > target.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
