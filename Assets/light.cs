using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }
    private void Update()
    {
        if (myLight.spotAngle >= minimumAngle)
            myLight.spotAngle -= angleDecay*Time.deltaTime;
        DecreaseIntensity();
    }

    void DecreaseIntensity()
    {
        if (myLight.intensity >= 0.3)
        {
            myLight.intensity -= lightDecay * Time.deltaTime;
        }
    }

    void restoreAngle(float intensityAmount)
    {
        myLight.intensity = 1f;
        myLight.spotAngle += intensityAmount;
    }
}
