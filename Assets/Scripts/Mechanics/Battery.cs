using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public PlayerInteraction torch;
    public float battery;
    [SerializeField] private float maxBattery;
    [SerializeField] private float drainAmount;
    [SerializeField] private Image batteryBar;
    [SerializeField] private float timer;
    [SerializeField] private float delay;

    private void Start()
    {
        battery = maxBattery;
    }

    private void Update()
    {
        DrainBattery();
    }

    private void DrainBattery()
    {
        if (torch.isOn)
        {
            // timer increases gradually
            timer += Time.deltaTime;

            // if timer is greater than or equal to delay
            if (timer >= delay)
            {
                timer = 0.0f;                       // timer is reset                                 
                battery -= drainAmount;
                batteryBar.fillAmount = battery / maxBattery;
            }
        }
    }
}
