using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelMoneyManager : MonoBehaviour
{
    public int money;
    public Text textDisplayText;

    private void Awake()
    {
        textDisplayText = GameObject.Find("Money").GetComponent<Text>();
        UpdateMoneyText();
    }


    void addMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    void spendMoney(int amount)
    {
        if ((money -= amount)> 0)
        {
            money = 0;
        }
        else
        {
            money -= amount;
        }
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        textDisplayText.text = money.ToString();
    }
}
