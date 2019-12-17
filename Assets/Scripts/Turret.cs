﻿using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{

    protected Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject rangeSphere;

    // Use this for initialization
    public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        rangeSphere = Instantiate(rangeSphere, transform.position, partToRotate.rotation);
        rangeSphere.transform.localScale = new Vector3(range, range, range);
    }

    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach ( GameObject enemy in enemies )
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if ( distanceToEnemy < shortestDistance )
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if ( nearestEnemy != null && shortestDistance <= range )
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    public void Update()
    {
        if ( target == null )
            return;

        //Target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        fireCooldown();

        if (BuildManager.instance.SpawnModeEnabled)
        {
            rangeSphere.SetActive(true);
            Debug.Log("is active ");
        } else
        {
            rangeSphere.SetActive(false);
        }
    }

    protected virtual void fireCooldown()
    {
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    protected virtual void Shoot()
    {
        GameObject bulletGO = ( GameObject )Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if ( bullet != null )
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}