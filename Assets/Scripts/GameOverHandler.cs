using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] Canvas PauseCanvas;
    void Start()
    {
        GameOverCanvas.enabled = false;
        PauseCanvas.enabled = false;
        //Keep this if, otherwise timescale wont back to 1
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvas.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void gameOver()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
