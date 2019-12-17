using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelMoneyManager : MonoBehaviour
{
    public static LevelMoneyManager instance;
    public int currentMoney;
    public Text textDisplayText;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one LevelMoneyManager in scene");
            return;
        }
        instance = this;
        textDisplayText = GameObject.Find("Money").GetComponent<Text>();
        UpdateMoneyText();
    }


    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
    }

    public void SpendMoney(int amount)
    {
        if ((currentMoney - amount) <= 0)
        {
            currentMoney = 0;
        }
        else
        {
            currentMoney -= amount;
        }
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        textDisplayText.text = currentMoney.ToString();
    }

    public bool CanAffordTo(int amount)
    {
        return ((currentMoney - amount) >= 0);
    }
}
