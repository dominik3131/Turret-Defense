using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    public GameObject selectedWeapon;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one WeaponManager in scene");
            return;
        }
        instance = this;
    }

    public void UpgradeSelectedWeapon()
    {
        instance.selectedWeapon.GetComponent<Weapon>().Upgrade();
    }
    public void SellSelectedWeapon()
    {
        if(instance.selectedWeapon != null)
        instance.selectedWeapon.GetComponent<Weapon>().Sell();
    }
}
