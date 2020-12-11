using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour//deals with player life and when damaged
{
    [SerializeField] int life;
    int currentLife;

    private void Start()
    {
        currentLife = life;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GREEN" || collision.tag == "BLUE" || collision.tag == "RED" || collision.tag == "YELLOW")// collision with any enemy
        {
            Destroy(collision.gameObject);
            currentLife--;
            CheckDeath();
        }
        else if(collision.tag == "Hunter")//collision with the hunter - insta lose
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    void CheckDeath()
    {
        if (currentLife <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
