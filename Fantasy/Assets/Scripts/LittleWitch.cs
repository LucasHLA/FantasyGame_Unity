using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleWitch : PlayerController
{
    private bool isShooting;
    public int healthAmount;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int healthMax;
    [SerializeField] private int healthMin;
    
    protected override void Start()
    {
        base.Start();
        healthMax = 5;
        healthMin = 1;
    }

    protected override void Update()
    {
        base.Update();
        Attack();
        HealthPower();
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
        if(Input.GetButtonDown("Fire1") && !isRunning && !isAttacking && !isJumping)
        {
            anim.SetInteger("state", 4);
            isAttacking = true;
            StartCoroutine(ThrowingMagic());
            StartCoroutine(OnShooting());
        }

        if(!isAttacking && isJumping && Input.GetButtonDown("Fire1"))
        {
            anim.SetInteger("state", 5);
            isAttacking = true;
            Shoot();
            StartCoroutine(OnShooting());
        }
    }

    private void HealthPower()
    {
        if(healthAmount >= healthMin && healthAmount <= healthMax)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                healthAmount--;
                health += 2;
                

            }
        }
    }

    
}
