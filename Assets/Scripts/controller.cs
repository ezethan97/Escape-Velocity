using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    [SerializeField] Canvas startUI;
    // Start is called before the first frame update
    void Start()
    { 
        SceneManager.LoadSceneAsync(2,LoadSceneMode.Additive);
    }
}
