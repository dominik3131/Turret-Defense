using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image foreground;
    [SerializeField]
    private float lossingLifeAnimation = 0.5f;

    private void Awake()
    {
        GetComponentInParent<Health>().OnHealthChanged += handleHealthChange;
    }

    private void handleHealthChange(float points)
    {
        StartCoroutine(changeHealthPoints(points));
    }

    private IEnumerator changeHealthPoints(float damage)
    {
        float photoFill = foreground.fillAmount;
        float elapsed = 0f;

        while(elapsed < lossingLifeAnimation)
        {
            elapsed += Time.deltaTime;
            foreground.fillAmount = Mathf.Lerp(photoFill, damage, elapsed / lossingLifeAnimation);
            yield return null;
        }

    }
}
