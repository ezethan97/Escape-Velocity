using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalEnemyHP : MonoBehaviour {

    [SerializeField] float FullHP = 100;
    float HP;

    private void Start()
    {
        name = transform.name;
        HP = FullHP;
    }

    public bool FullHealth()
    {
        if (HP != FullHP)
        {
            return false;
        }
        else return true;
    }

    public void Damage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
            if (GetComponent<VictoryController>()!= null)
            {
                GetComponent<VictoryController>().Victory();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        if (name.Contains("Giant"))
        {
            GetComponent<Giant_controller>().isProvoked = true;
        }
        else if (name.Contains("Enemy"))
        {
            GetComponent<Enemy_Controller>().isProvoked = true;
        }
    }
}
