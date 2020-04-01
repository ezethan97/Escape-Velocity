using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
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
}
