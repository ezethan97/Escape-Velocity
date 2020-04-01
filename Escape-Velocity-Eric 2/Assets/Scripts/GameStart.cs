using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void loadStartScene()
    {
        SceneManager.LoadScene(2);
    }
}
