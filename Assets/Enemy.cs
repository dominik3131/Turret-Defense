using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 5;

    private Transform target;

    private int wavePointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }
    void Update()
    {

            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * 3 * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                getNextWaypoint();
            }

    }
    void getNextWaypoint()
    {
        
            if (wavePointIndex >= Waypoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            wavePointIndex++;
            target = Waypoints.points[wavePointIndex];
        
        
    }
}
