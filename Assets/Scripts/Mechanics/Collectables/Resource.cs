using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    [Header("Script References")]
    public Energy energy;
    [Header("Setup")]
    public int wood;
    public int woodInWorld;
    [SerializeField] private Text woodText;

    private void Start()
    {
        woodText.text = wood.ToString();     
    }

    #region Lose/Gain Wood
    public void LoseWood(int amount)
    {
        wood -= amount;
        woodText.text = wood.ToString();
        woodInWorld -= amount;
    }

    public void GainWood(int amount)
    {
        wood += amount;
        woodText.text = wood.ToString();
    }
    #endregion
}
