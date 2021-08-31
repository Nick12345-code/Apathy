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
        // if player loses all health
        if (health <= 0)
        {
            ResetHealth();
            SceneManagement.LoseGame();
        }
    }

    // lose health and update HUD
    public void LoseHealth(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString("0");
    }

    // gain health and update HUD
    public void GainHealth(float amount)
    {
        health += amount;
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health.ToString("0");
    }

    // set health to 0 and update HUD
    public void ResetHealth()
    {
        health = 0;
        healthText.text = health.ToString("0");
        healthBar.fillAmount = health / maxHealth;
    }
}
