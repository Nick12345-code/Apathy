using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    [SerializeField] private int gold;
    [SerializeField] private Text goldText;

    #region Lose/Gain Gold
    public void LoseGold(int amount)
    {
        gold -= amount;
        goldText.text = gold.ToString();
    }

    public void GainGold(int amount)
    {
        gold += amount;
        goldText.text = gold.ToString();
    }
    #endregion
}
