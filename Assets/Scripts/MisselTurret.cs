using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisselTurret : Turret
{
    public GameObject missleInCannon;
    
    private float loadMissleCounter=0.3f;

    public void Update()
    {
        base.Update();
        loadMissleCounter -= Time.deltaTime;
        if (loadMissleCounter < 0f)
        {
            missleInCannon.SetActive(true);
        }
    }

    protected override void Shoot()
    {
        base.Shoot();
        missleInCannon.SetActive(false);
        loadMissleCounter = 0.3f;
    }
}
