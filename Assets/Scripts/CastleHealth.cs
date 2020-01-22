using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : Health
{
    public override void DeathActions()
    {
        GameOverManager.instance.Die();
    }
    public void Revive()
    {
        currentHealth = maxHealth;
    }

}
