using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    Object[] obj;
    void Start()
    {
        obj =FindObjectsOfType<trainingEnemy>();
        for (int i = 0; i < obj.Length; i++)
        {
            Debug.Log(i);
        }
    }

    private void Update()
    {
        if (EnemyClear())
        {
            Destroy(transform.gameObject);
        }
    }

    bool EnemyClear()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] != null)
                return false;
        }
        return true;
    }
}
