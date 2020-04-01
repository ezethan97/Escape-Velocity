using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class cabine : MonoBehaviour {

    [SerializeField] Camera MainCamera;
    [SerializeField] public float damage = 25f;
    [SerializeField] int range = 100;
    [SerializeField] ParticleSystem GunFire;
    [SerializeField] GameObject HitEffect;
    [SerializeField] int FOVnormal = 30;
    [SerializeField] float normalSensitivity = 2.0f;
    [SerializeField] float zoomingSensitivity = 1.0f;
    [SerializeField] int FOVzooming = 15;
    
    Boolean aiming = false;
    Boolean reloading = false;
    RigidbodyFirstPersonController controller;
    int maximumAmmo = 31;
    int currentAmmo = 31;
    float lastShootTime;
    private void Start()
    {
        
        controller = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        zooming();
		
	}

    private void zooming()
    {
        if (Input.GetMouseButton(1))
        {
            MainCamera.fieldOfView = FOVzooming;
            aiming = true;
            controller.mouseLook.XSensitivity = zoomingSensitivity;
            controller.mouseLook.YSensitivity = zoomingSensitivity;
        }
        if (Input.GetMouseButtonUp(1)&&aiming == true)
        {
            aiming = false;
            MainCamera.fieldOfView = FOVnormal;
            controller.mouseLook.XSensitivity = normalSensitivity;
            controller.mouseLook.YSensitivity = normalSensitivity;
            Debug.Log(controller.mouseLook.XSensitivity);
        }
    }

    private void Shoot()
    {
            currentAmmo--;
            GunFire.Play();
            RaycastHit hit;
            if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, range))
            {
                GameObject hitEffect = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 0.05f);
                if (hit.transform.GetComponent<normalEnemyHP>() == null) return;
                normalEnemyHP HP = hit.transform.GetComponent<normalEnemyHP>();
                HP.Damage(damage);
            }
            else return;
    }
}
