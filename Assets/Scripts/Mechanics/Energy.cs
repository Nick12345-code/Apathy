using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [Header("Setup")]
    public float energy;
    [SerializeField] private float maxEnergy;
    [SerializeField] private Text energyText;
    [SerializeField] private Image energyBar;
    [Header("Wood Burning")]
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private GameObject fire;

    private void Start()
    {
        energy = maxEnergy;
        energyText.text = energy.ToString();
        energyBar.fillAmount = energy / maxEnergy;
        fire.SetActive(true);
    }

    private void Update()
    {
        // if no energy left
        if (energy <= 0)
        {
            FireOut();
        }
        else
        {
            // timer increases gradually
            timer += Time.deltaTime;

            // if timer is greater than or equal to the delay
            if (timer >= delay)
            {           
                timer = 0.0f;       // timer is reset
                LoseEnergy(1.0f);   // lose 1 energy
            }
        }
    }

    // lose energy and update HUD
    public void LoseEnergy(float amount)
    {
        energy -= amount;
        energyText.text = energy.ToString();
        energyBar.fillAmount = energy / maxEnergy;
    }

    // gain energy and update HUD
    public void GainEnergy(float amount)
    {
        energy += amount;
        energyText.text = energy.ToString();
        energyBar.fillAmount = energy / maxEnergy;
    }

    // fire is disabled
    private void FireOut()
    {
        fire.SetActive(false);
    }
}
