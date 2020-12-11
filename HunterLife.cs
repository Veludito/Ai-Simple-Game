using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterLife : MonoBehaviour//deals with hunter life
{
    [SerializeField] float life;
    [SerializeField] float timeToHeal;
    public static float currentLife;
    float currentTime;

    private void Start()
    {
        currentLife = life;
    }

    private void Update()
    {
        if(currentTime <= 0)//heals over time
        {
            Heal();
            currentTime = timeToHeal;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    void Heal()
    {
        currentLife += 5;
        if (currentLife > life)
            currentLife = life;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")//damaged by player bullets
        {
            currentLife--;
            Destroy(collision.gameObject);
        }
    }
}
