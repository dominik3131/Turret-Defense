using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float initialSpeed = 2f;
    public int damage = 5;
    public int moneyValue = 100;
    private bool freezed = false;
    private Transform target;
    private int wavePointIndex = 0;
    private float speed;
    public GameObject healthbar;
    void Start()
    {
        target = Waypoints.points[0];
        speed = initialSpeed;
    }
    void Update()
    {
        if ( !freezed )
        {
            Vector3 direction = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            if ( healthbar )
            {
                healthbar.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
            }

            if ( Vector3.Distance(transform.position, target.position) <= 0.4f )
            {
                getNextWaypoint();
            }
            speed = initialSpeed;
        }
    }
    void getNextWaypoint()
    {
        if ( wavePointIndex >= Waypoints.points.Length - 1 )
        {
            CastleHealth.instance.TakeDamage(damage);
            WaveSpanner.enemiesAlive--;
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];

    }

    public void decreaseSpeed(float slowDown)
    {
        speed = initialSpeed - initialSpeed * slowDown;
    }

    public void Freeze()
    {
        freezed = true;
    }
    public void UnFreeze()
    {
        freezed = false;
    }
}

