using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealthManager : MonoBehaviour
{
    public Image healthbar;
    public TMP_Text bossNameText;
    public int healthAmount = 100;
    public GameObject bossObject;

    void Start()
    {

        if (bossObject == null)
        {
            bossObject = gameObject;
        }

        if (bossNameText != null)
        {
            bossNameText.text = bossObject.name;
        }
    }

    public void TakeDamage(int damage)
    {
        healthAmount -= damage;
        healthbar.fillAmount = healthAmount / 100f;

        if (healthAmount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (bossObject != null)
        {
            bossObject.SetActive(false);
        }
    }
}
