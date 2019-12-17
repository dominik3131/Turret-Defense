using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Button fireButton;
    public Button freezeButton;
    public Image overlay;
    public int firePotionDamage = 100;
    public float freezeTime = 2.5f;
    void Start()
    {
        fireButton.onClick.AddListener(UseFirePotion);
        freezeButton.onClick.AddListener(UseFreezePotion);
        fireButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("FIRE_POTIONS").ToString();
        freezeButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetInt("FREEZE_POTIONS").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UseFirePotion()
    {
        int potions = PlayerPrefs.GetInt("FIRE_POTIONS");
        if ( potions > 0 )
        {
            fireButton.GetComponent<AudioSource>().Play();
            StartCoroutine(RedOverlay());
            BurnEnemies();
            PlayerPrefs.SetInt("FIRE_POTIONS", potions - 1);

            fireButton.GetComponentInChildren<Text>().text = (potions - 1).ToString();
        }
    }
    private void UseFreezePotion()
    {
        int potions = PlayerPrefs.GetInt("FREEZE_POTIONS");
        if ( potions > 0 )
        {
            freezeButton.GetComponent<AudioSource>().Play();
            StartCoroutine(BlueOverlay());
            StartCoroutine(FreezeEnemies());
            PlayerPrefs.SetInt("FREEZE_POTIONS", potions - 1);
            freezeButton.GetComponentInChildren<Text>().text = (potions - 1).ToString();
        }
    }
    IEnumerator RedOverlay()
    {
        Color red = new Color(1, 0, 0, 0.3f);
        overlay.color = red;
        yield return new WaitForSeconds(0.5f);
        red.a = 0f;
        overlay.color = red;
    }
    IEnumerator BlueOverlay()
    {
        Color blue = new Color(0, 0, 1, 0.3f);
        overlay.color = blue;
        yield return new WaitForSeconds(2);
        blue.a = 0f;
        overlay.color = blue;
    }
    IEnumerator FreezeEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach ( GameObject gameObject in enemies )
        {
            Debug.Log(enemies.Length);
            Enemy enemy = gameObject.GetComponent<Enemy>();
            if ( enemy )
            {
                enemy.Freeze();
            }
        }
        yield return new WaitForSeconds(2);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach ( GameObject gameObject in enemies )
        {
            Enemy enemy = gameObject.GetComponent<Enemy>();
            if ( enemy )
            {
                enemy.UnFreeze();
            }
        }
    }
    void BurnEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach ( GameObject gameObject in enemies )
        {
            Debug.Log(enemies.Length);
            Health enemy = gameObject.GetComponent<Health>();
            if ( enemy )
            {
                enemy.takeDamage(firePotionDamage);
            }
        }
    }

}
