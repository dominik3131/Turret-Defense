using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject == null && !ReferenceEquals(gameObject,null))
        {
            showLossingScreen();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<Health>().TakeDamage(collision.gameObject.GetComponent<Enemy>().damage);
        }
    }

    private void showLossingScreen()
    {
        Debug.Log("end of the game");
    }
}
