using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float PlayerHealth = 100f;
    [SerializeField] Canvas gameOver;
    [SerializeField] Canvas bag;
    [SerializeField] Canvas crafting;
    [SerializeField] Canvas victory;
    private void Start()
    {
        gameOver.enabled = false;
        bag.enabled = false;
        crafting.enabled = false;
        victory.enabled = false;
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -5)
        {
            GetComponent<GameOverHandler>().gameOver();
        }
    }

    public void DamageTaken(float damage)
    {
        PlayerHealth -= damage;
        if (PlayerHealth <= 0)
        {
            GetComponent<GameOverHandler>().gameOver();
        }
    }
}
