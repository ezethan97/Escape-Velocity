using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    cabine gun;
    generalUI UIcontroller;
    private void Start()
    {
        UIcontroller = FindObjectOfType<generalUI>();
        gun = FindObjectOfType<cabine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        UIcontroller.displayGun();
        gun.damage = gun.damage * 1.5f;
        Destroy(transform.gameObject);
    }

}
