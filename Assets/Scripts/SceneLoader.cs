using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Transform first;
    [SerializeField] Transform second;

    void Update()
    {
        if ((transform.position - first.position).magnitude <= 5f)
        {
            SceneManager.LoadScene(2);
        }
        else if ((transform.position - second.position).magnitude <= 5f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
