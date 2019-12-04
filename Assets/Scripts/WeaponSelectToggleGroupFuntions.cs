using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Linq;

public class WeaponSelectToggleGroupFuntions : MonoBehaviour
{   
    public void SwitchWeapon(int toggleIndex) {
        GameObject map = GameObject.Find("Map");
        ToggleGroup group = gameObject.GetComponents<ToggleGroup>()[0]; 
        bool active = group.AnyTogglesOn();
        map.GetComponent<MapFunctions>().HighlightFreeNodes(active);
        //int index = group.ActiveToggles().FirstOrDefault().
        BuildManager.instance.SetWeaponToBuild(toggleIndex);

    }
}
