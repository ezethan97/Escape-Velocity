using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField] Canvas VictoryCanvas;

    public void Victory()
    {
        VictoryCanvas.enabled=true;
        Time.timeScale = 0;
    }
}
