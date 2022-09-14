using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool bound;
    [SerializeField] private float xMin;
    [SerializeField] private float yMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMax;

    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed)+ new Vector3(0,0,-10);

            if (bound)
            {
                transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
            }
        }

        
    }
}
