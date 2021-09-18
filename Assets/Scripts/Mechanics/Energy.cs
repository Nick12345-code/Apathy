using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [Header("Setup")]
    public float energy;
    [SerializeField] private float maxEnergy;
    [SerializeField] private Image energyBar;
    [SerializeField] private ParticleSystem fireParticles;
    [SerializeField] private ParticleSystem smokeParticles;
    [Header("Wood Burning")]
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private GameObject fire;
    [SerializeField] private AudioSource campfireSound;

    private void Start()
    {
        energy = maxEnergy;
        energyBar.fillAmount = energy / maxEnergy;
        fire.SetActive(true);
    }

    private void Update()
    {
        // if no energy left
        if (energy <= 0)
        {
            fireParticles.Stop();
            smokeParticles.Stop();
            Invoke("FireOut", 1);
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
        energyBar.fillAmount = Mathf.Lerp(energyBar.fillAmount, energy / maxEnergy, 1);
    }

    // gain energy and update HUD
    public void GainEnergy(float amount)
    {
        energy += amount;
        energyBar.fillAmount = energy / maxEnergy;
    }

    // fire is disabled
    private void FireOut()
    {
        fire.SetActive(false);
        campfireSound.enabled = false;
    }
}
