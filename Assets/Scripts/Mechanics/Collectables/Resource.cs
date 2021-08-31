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

    // lose wood and update HUD
    public void LoseWood(int amount)
    {
        wood -= amount;
        woodText.text = wood.ToString();
        woodInWorld -= amount;
    }

    // gain wood and update HUD
    public void GainWood(int amount)
    {
        wood += amount;
        woodText.text = wood.ToString();
    }
}
