using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private Text healthText;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        #region When Player Loses All Health
        if (health <= 0)
        {
            ResetHealth();
            SceneManagement.LoseGame();
        }
        #endregion
    }

    #region Lose/Gain Health
    public void LoseHealth(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString("0");
    }

    public void GainHealth(float amount)
    {
        health += amount;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString("0");
    }

    public void ResetHealth()
    {
        health = 0;
        healthText.text = health.ToString("0");
        healthBar.fillAmount = health / maxHealth;
    }
    #endregion
}
