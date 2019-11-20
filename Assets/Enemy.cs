using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;

    private Transform target;

    private int wavePointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }
    void Update()
    {
        if(gameObject.active)
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * 3 * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                getNextWaypoint();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void getNextWaypoint()
    {
        
            if (wavePointIndex >= Waypoints.points.Length - 1)
            {
            gameObject.SetActive(false);
                
                return;
            }
            wavePointIndex++;
            target = Waypoints.points[wavePointIndex];
        
        
    }
}
