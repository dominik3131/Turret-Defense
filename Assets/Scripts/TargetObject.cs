using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public float rangeOfDestroy = 0.5f;
    public int health;

    void Start()
    {
        health = 100;
    }
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            showLossingScreen();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            health -= collision.gameObject.GetComponent<Enemy>().damage;
        }
    }

    private void showLossingScreen()
    {
        Destroy(gameObject);
    }
}
