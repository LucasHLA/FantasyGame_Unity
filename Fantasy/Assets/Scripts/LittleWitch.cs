using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleWitch : PlayerController
{
    private bool isShooting;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Attack();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    IEnumerator OnShooting()
    {
        yield return new WaitForSeconds(.6f);
        isShooting = false;
        isAttacking = false;
    }

    IEnumerator ThrowingMagic()
    {
        yield return new WaitForSeconds(.6f);
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    } 

    private void Attack()
    {
        if(Input.GetButtonDown("Fire1") && !isRunning && !isAttacking)
        {
            anim.SetInteger("state", 4);
            isAttacking = true;
            StartCoroutine(ThrowingMagic());
            StartCoroutine(OnShooting());
        }
    }
}
