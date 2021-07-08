using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public Energy energy;
    [Header("Wood")]
    public int wood = 0;
    public int woodInWorld = 0;
    [SerializeField] private Text woodText;

    private void Start()
    {
        woodText.text = wood.ToString();     
    }

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
}
