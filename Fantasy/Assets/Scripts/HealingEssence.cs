using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEssence : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private LayerMask ground;
    [SerializeField] private int xImpulse;
    [SerializeField] private int yImpulse;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        rb.AddForce(Vector2.up * yImpulse, ForceMode2D.Impulse);
        Destroy(this.gameObject, 7f);
    }

    private void Update()
    {
        if (rb.IsTouchingLayers(ground))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.velocity = Vector2.zero;
        }
    }
}
