using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [Header("Energy")]
    public float energy;
    [SerializeField] private float maxEnergy = 100.0f;
    [SerializeField] private Text energyText;
    [SerializeField] private Image energyBar;
    [Header("Burning Wood")]
    [SerializeField] private float timer;
    [SerializeField] private float delay = 1.0f;
    [SerializeField] private GameObject fire;

    private void Start()
    {
        energy = maxEnergy;
        energyText.text = energy.ToString();
        fire.SetActive(true);
    }

    private void Update()
    {
        if (energy <= 0)
        {
            FireOut();
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                timer = 0.0f;
                LoseEnergy(1.0f);
            }
        }
    }

    #region lose/gain energy functions
    public void LoseEnergy(float amount)
    {
        energy -= amount;
        energyText.text = energy.ToString();
        energyBar.fillAmount = energy / maxEnergy;
    }

    public void GainEnergy(float amount)
    {
        energy += amount;
        energyText.text = energy.ToString();
        energyBar.fillAmount = energy / maxEnergy;
    }
    #endregion

    private void FireOut()
    {
        fire.SetActive(false);
    }
}
