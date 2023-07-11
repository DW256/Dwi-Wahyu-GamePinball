using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractButton : MonoBehaviour
{
    public void retryStage()
    {
        // Mengambil nama scene saat ini
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Memuat ulang scene saat ini
        SceneManager.LoadScene(currentSceneName);

        Time.timeScale = 1;
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
