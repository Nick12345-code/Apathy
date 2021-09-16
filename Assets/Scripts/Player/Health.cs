using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;
    [Header("Losing Health")]
    public bool losingHealth;
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private float fireDamage;

    private void Start() => health = maxHealth;

    private void Update()
    {
        DrainHealth(fireDamage);
        Die();
    }

    private void DrainHealth(float amount)
    {
        if (losingHealth)
        {
            // timer increases gradually
            timer += Time.deltaTime;

            // if timer is greater than or equal to delay
            if (timer >= delay)
            {
                timer = 0.0f;                       // timer is reset                                 
                health -= amount;
                healthBar.fillAmount = health / maxHealth;
            }
        }
    }

    private void Die()
    {
        // if player loses all health
        if (health <= 0) SceneManagement.LoseGame();
    }
}
