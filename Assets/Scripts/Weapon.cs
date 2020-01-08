using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour
{
    public bool isSelected = false;
    public int level = 1;
    public int price = 200;
    public int upgradePrice = 150;
    public Node node;

    public bool Upgrade()
    {
        if (level == 3) return false;
        if (LevelMoneyManager.instance.CanAffordTo(upgradePrice*level))
        {
            LevelMoneyManager.instance.SpendMoney(upgradePrice*level);
            level += 1;
            UpgradeLook();
            UpgradeActivity();
           // Debug.Log(gameObject.name + " upgraded !");
            return true;
        }
        else
        {
            return false;
        }
        
    }
    virtual public void UpgradeLook()
    {

    }
    virtual public void UpgradeActivity()
    {

    }
    public void Sell()
    {
        LevelMoneyManager.instance.AddMoney((int) price/2);
        //Debug.Log(gameObject.name + " sold!");
        node.isTaken = false;
        Destroy(gameObject);
    }
    void OnMouseDown()
    {
        Weapon[] selected = FindObjectsOfType<Weapon>().Where(c => c.isSelected).ToArray();
        isSelected = true;
        if (selected.Any())
                selected[0].isSelected = !selected[0].isSelected;
        if(isSelected)
            WeaponManager.instance.selectedWeapon = gameObject;
        else
            WeaponManager.instance.selectedWeapon = null;


    }
}
