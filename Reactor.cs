using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Reactor : MonoBehaviour
{
    [SerializeField] int startLife;
    int currentLife;

    private void Start()
    {
        currentLife = startLife;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collide with a bullet, destroy the bullet, decrease reactor life and check if life is bellow 0
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            currentLife--;
            CheckDeath();
        }
    }

    void CheckDeath()
    {
        if(currentLife <= 0)//if bellow 0, destroy itself
        {
            GameObject[] reactors = GameObject.FindGameObjectsWithTag("Reactor");

            if (reactors.Length == 1)//if is the last reactor, end game
                SceneManager.LoadScene("WinScene");

            OnReactorDestroyed.Invoke();
            Destroy(gameObject);
        }
    }

    public static UnityEvent OnReactorDestroyed = new UnityEvent();
}
