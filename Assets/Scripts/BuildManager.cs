using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public bool SpawnModeEnabled = false;
    public GameObject standardTurretPrefab;
    private GameObject turretToBuild;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Buildmanager in scene");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void EnableSpawnMode()
    {
        SpawnModeEnabled = true;
    }
    public void DisableSpawnMode()
    {
        SpawnModeEnabled = false;
    }
}