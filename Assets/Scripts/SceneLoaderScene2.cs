using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScene2 : MonoBehaviour
{
    [SerializeField] Transform door;
    [SerializeField] Transform door2;
    void Update()
    {
        if ((transform.position - door.position).magnitude <= 5)
        {
            SceneManager.LoadScene(1);
        }
        if ((transform.position - door2.position).magnitude <= 5)
        {
            SceneManager.LoadScene(1);
        }
    }
}
