using System.Collections;
using System.Collections.Generic;
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
        #region Fire Slowly Burning Up  
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
        #endregion
    }

    #region Lose/Gain Energy
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

    #region Fire Is Extinguished
    private void FireOut()
    {
        fire.SetActive(false);
    }
    #endregion
}
