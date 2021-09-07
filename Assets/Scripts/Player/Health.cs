using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        // if player loses all health
        if (health <= 0)
        {
            SceneManagement.LoseGame();
        }
    }

    // lose health and update HUD
    public void LoseHealth(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
    }

    public IEnumerator DrainHealth()
    {
        while (true)
        {
            LoseHealth(1);
            yield return new WaitForSeconds(1f);
        }
    }
}
