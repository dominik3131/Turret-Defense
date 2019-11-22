using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // set to true blocks object spawning on map node
    public bool canNotSpawnHere;
    private GameObject turret;
    
    void OnMouseDown()
    {
        if (canNotSpawnHere)
        {
            if (turret != null)
            {
                Debug.Log("Can't build object.");
                return;
            }
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            float height = turretToBuild.transform.lossyScale.y / 2;
            Vector3 temp = new Vector3(transform.position.x, transform.position.y + 1 + height, transform.position.z);

            turret = (GameObject)Instantiate(turretToBuild, temp, transform.rotation);
            Debug.Log("Turret placed.");
        }
        else
        {
            return;
        }
        
    }
}
