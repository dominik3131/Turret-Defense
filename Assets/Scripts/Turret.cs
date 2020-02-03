using System;
using System.Collections;
using UnityEngine;

public class Turret : Weapon
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

    private GameObject indicator;


    // Use this for initialization
    public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        rangeSphere = Instantiate(rangeSphere, transform.position, partToRotate.rotation);
        rangeSphere.transform.localScale = new Vector3(2 * range, 0.1f, 2 * range);

        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        foreach ( Transform t in ts )
            if ( t.gameObject.name == "Indicator" )
            {
                indicator = t.gameObject;
            }
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
        if ( isSelected )
        {
            indicator.GetComponent<SpriteRenderer>().enabled = true;
            rangeSphere.SetActive(true);
        }
        else
        {
            indicator.GetComponent<SpriteRenderer>().enabled = false;
            rangeSphere.SetActive(false);
        }

        if ( target == null )
            return;

        //Target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        fireCooldown();
    }

    protected virtual void fireCooldown()
    {
        if ( fireCountdown <= 0f )
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

    public override void UpgradeLook()
    {
        base.UpgradeLook();
        Vector3 vec = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(vec.x * ( float )1.1, vec.y * ( float )1.1, vec.z * ( float )1.1);
        Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach ( Renderer r in renderers )
        {
            foreach ( Material m in r.materials )
            {
                if ( m.name != "Sprites-Default" )
                    Debug.Log("upgrade");
                m.color += new Color(0.44f, 0.1f, 0.1f);
            }
        }

    }

    public override void UpgradeActivity()
    {
        base.UpgradeActivity();
        range += level;
        bulletPrefab.GetComponent<Bullet>().damage += level;
    }

    public override void Sell()
    {
        base.Sell();
        rangeSphere.SetActive(false);
    }

}