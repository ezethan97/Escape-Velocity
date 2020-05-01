using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        Application.Quit();
    }

    public void resumeGame()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        pauseCanvas.enabled = false;
    }
}
