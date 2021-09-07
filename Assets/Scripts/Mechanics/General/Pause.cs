using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool paused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        // if escape button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if paused, resume game
            if (paused == true) 
            {
                ResumeGame();
            }
            // if not paused, pause game
            else if (paused == false)
            {
                PauseGame();
            } 
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;          // freezes time
        pauseMenu.SetActive(true);      // opens pause screen
        paused = true;                  // paused set to true
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;          // time unfrozen
        pauseMenu.SetActive(false);     // closes pause screen
        paused = false;                 // paused set to false
    }
}
