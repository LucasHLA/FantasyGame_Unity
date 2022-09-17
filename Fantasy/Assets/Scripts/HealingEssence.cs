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
        StartCoroutine(freezeEssence());
        Destroy(this.gameObject, 7f);
    }

    IEnumerator freezeEssence()
    {
        yield return new WaitForSeconds(1f);
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
}
