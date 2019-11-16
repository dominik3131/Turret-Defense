using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turret;
    
    void OnMouseDown()
    {
        Debug.Log("welcome");
        if (turret != null)
        {
            Debug.Log("cant build");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        Debug.Log("placed");
    }
}
