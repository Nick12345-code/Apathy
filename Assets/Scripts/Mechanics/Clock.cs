using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] private float timeLeft;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        TimeLeft();
    }

    private void TimeLeft()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = timeLeft.ToString("0"); 
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
