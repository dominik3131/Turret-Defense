using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{
    [Header("Laser Atrributes")]
    public float maxDamage = 4f;
    public float minDamage = 0.1f;
    public float slowdown = 1f;
    public LineRenderer laserLine;

    private float currentDamage;

    public void Start()
    {
        base.Start();
        currentDamage = minDamage;
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        if ( target == null )
        {
            laserLine.enabled = false;
            currentDamage = minDamage;
        }

    }

    protected override void Shoot()
    {
        if ( !laserLine.enabled )
        {
            laserLine.enabled = true;
        }
        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, target.position);
        target.gameObject.GetComponentInChildren<Enemy>().decreaseSpeed(2f);
        target.gameObject.GetComponentInChildren<Health>().TakeDamage(currentDamage < maxDamage ? currentDamage * Time.deltaTime * 100 : maxDamage);
    }

    protected override void fireCooldown()
    {
        Shoot();
    }
}
