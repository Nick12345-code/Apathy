using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }

    public static void LoseGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Lose");
    }
}
