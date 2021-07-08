using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool paused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                ResumeGame();
            }
            else if (paused == false)
            {
                PauseGame();
            } 
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        paused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        paused = false;
    }
}
