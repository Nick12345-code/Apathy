using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public float mana;
    [SerializeField] private float maxMana;
    [SerializeField] private Image manaBar;
    [SerializeField] private Text manaText;

    private void Start()
    {
        mana = maxMana;
    }

    // lose mana and update HUD
    public void LoseMana(float amount)
    {
        mana -= amount;
        manaBar.fillAmount = mana / maxMana;
        manaText.text = mana.ToString("0");
    }

    // gain mana and update HUD
    public void GainMana(float amount)
    {
        mana += amount;
        manaBar.fillAmount = mana / maxMana;
        manaText.text = mana.ToString("0");
    }
}
