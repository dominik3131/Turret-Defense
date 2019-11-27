using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFunctions : MonoBehaviour
{
    public GameObject NodePrefab;
    public void HighlightFreeNodes(bool value)
    {
        BuildManager.instance.SpawnModeEnabled = value;
        GameObject cameraPerspective = GameObject.Find("CameraPerspective");
        if (value)
        {   
            cameraPerspective.transform.GetComponent<CameraMovement>().BlockCameraMovement();
            SetNodesColor(NodePrefab.GetComponent<Renderer>().sharedMaterial.color * 0.2f);

        }
        else
        {
            cameraPerspective.transform.GetComponent<CameraMovement>().UnlockCameraMovement();
            SetNodesColor(NodePrefab.GetComponent<Renderer>().sharedMaterial.color);
        }
        
        
    }
    private void SetNodesColor(Color color)
    {
        Transform[] table = transform.GetComponentsInChildren<Transform>();
        foreach (Transform obj in table)
        {
            if (obj.name.ToString().Contains(NodePrefab.name))
            {
                
                if (!obj.GetComponent<Node>().canNotSpawnHere)
                {
                    obj.GetComponent<Renderer>().material.color = color;
                }

            }
        }
    }
}
