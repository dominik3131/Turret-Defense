using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : Health
{
    public static CastleHealth instance;
    private void Awake()
    {
        if ( instance != null )
        {
            return;
        }
        instance = this;
    }
    public override void DeathActions()
    {
        GameOverManager.instance.Die();
    }
    public void Revive()
    {
        currentHealth = maxHealth;
    }

}
