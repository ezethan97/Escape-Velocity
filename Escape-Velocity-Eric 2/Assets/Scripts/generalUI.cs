using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class generalUI : MonoBehaviour
{
    [SerializeField] Text gunfire;
    [SerializeField] Canvas Pause;
    private float timeCounter ;
    private float displayTimeGun;
    private float displayTimeLife;
    private float displayTimeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gunfire.enabled = false;
        Pause.enabled = false;
        timeCounter = 0;
        displayTimeGun = 3.0f;
        displayTimeLife = 3.0f;
        displayTimeSpeed = 3.0f;
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if (gunfire.enabled == true)
        {
            displayTimeGun -= Time.deltaTime;
        }
        else displayTimeGun = 3.0f;
        if (displayTimeGun <= 0)
        {
            gunfire.enabled = false;
            displayTimeGun = 3.0f;
        }
        if (Input.GetKeyDown("Escape"))
        {
            Pause.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public float getTime()
    {
        return timeCounter;
    }

    public void displayGun()
    {
        gunfire.enabled = true;

    }
    public void continueInGame()
    {
        Time.timeScale = 1;
        Pause.enabled = false;
    }
}
