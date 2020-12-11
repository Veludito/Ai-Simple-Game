using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 10f;
    [SerializeField] float movementSpeed = 10f;
    AgentType bulletColor;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
        bulletColor = ColorChanger.currentColor;
        SetColor();
    }

    private void Update()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
    }

    public void SetColor()
    {
        GetComponent<SpriteRenderer>().color = ColorChanger.GetCurrentColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == bulletColor.ToString())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
