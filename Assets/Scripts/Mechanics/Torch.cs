using UnityEngine;
using UnityEngine.UI;

public class Torch : MonoBehaviour
{
    [SerializeField] private Image batteryBar;
    [SerializeField] private Light torch;
    [SerializeField] private float battery;
    [SerializeField] private float maxBattery;
    [SerializeField] private float drainAmount;
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private bool on;

    private void Start()
    {
        battery = maxBattery;
        torch.enabled = false;
    }

    private void Update()
    {
        DrainBattery();
    }

    public void Activate()
    {
        if (on)
        {
            on = false;
            torch.enabled = false;
        }
        else if (!on)
        {
            on = true;
            torch.enabled = true;
        }
    }

    private void DrainBattery()
    {
        if (battery > 0)
        {
            if (on)
            {
                // timer increases gradually
                timer += Time.deltaTime;

                // if timer is greater than or equal to delay
                if (timer >= delay)
                {
                    // timer reset
                    timer = 0.0f;        
                    // battery decreases by drainAmount
                    battery -= drainAmount;
                    // battery bar represents this visually
                    batteryBar.fillAmount = battery / maxBattery;
                }
            } 
        }
        else
        {
            // not best way to turn off the light but yeah works
            Destroy(torch);
        }
    }
}
