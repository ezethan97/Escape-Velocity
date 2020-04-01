using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerEvent : MonoBehaviour
{
    [SerializeField] Text tutorial;
    [SerializeField] Text nextTutorial;
    private void Start()
    {
        try
        {
            nextTutorial.enabled = false;
        }
        catch (NullReferenceException e) 
        {
            Debug.Log("Toturial end or error");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        tutorial.enabled = false;
        if (nextTutorial!=null)
            nextTutorial.enabled = true;
        GameObject.Destroy(transform.gameObject);
    }

}
