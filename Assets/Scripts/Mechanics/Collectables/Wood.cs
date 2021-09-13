using UnityEngine;
using TMPro;

public class Wood : MonoBehaviour
{
    public int wood;
    public int woodInWorld;
    [SerializeField] private TextMeshProUGUI woodText;

    private void Start()
    {
        woodText.text = wood.ToString();     
    }

    // lose wood and update HUD
    public void LoseWood(int amount)
    {
        wood -= amount;
        woodText.text = wood.ToString();
    }

    // gain wood and update HUD
    public void GainWood(int amount)
    {
        wood += amount;
        woodInWorld -= amount;
        woodText.text = wood.ToString();
    }
}
