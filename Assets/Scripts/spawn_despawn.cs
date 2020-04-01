using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_despawn : MonoBehaviour
{
    public float distance = 10;
    private GameObject player;
    private GameObject [] terrains;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        terrains = GameObject.FindGameObjectsWithTag("Terrain");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject terrain in terrains)
        {
            if (Vector3.Distance(terrain.transform.position,player.transform.position) > distance)
                terrain.SetActive(false);
            else
                terrain.SetActive(true);
        }
    }
}
