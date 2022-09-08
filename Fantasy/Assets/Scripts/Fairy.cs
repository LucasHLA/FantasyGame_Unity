using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Fairy : MonoBehaviour
{
    [SerializeField] private AIPath aiPath;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x > 0)
        {
            anim.SetInteger("state", 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if( aiPath.desiredVelocity.x < 0)
        {
            anim.SetInteger("state", 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            anim.SetInteger("state", 0);
        }
    }
}
