using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour
{
    public bool isSelected = false;
    public void Upgrade()
    {
        Debug.Log(gameObject.name + " upgraded !");
    }
    public void Sell()
    {
        Debug.Log(gameObject.name + " sold!");
    }
    void OnMouseDown()
    {
        Weapon[] selected = FindObjectsOfType<Weapon>().Where(c => c.isSelected).ToArray();
            if(selected.Any())
                selected[0].isSelected = false;
        WeaponManager.instance.selectedWeapon = gameObject;
        isSelected = true;
    }
}
