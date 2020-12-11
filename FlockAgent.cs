using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    [SerializeField] Sprite red, yellow, blue, green;

    Collider2D agentCollider;
    public Collider2D AgenteCollider { get { return agentCollider; } }

    private void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    public void SetColor(AgentType agentColor)
    {
        Sprite newSprite = blue;

        switch (agentColor)
        {
            case AgentType.BLUE:
                newSprite = blue;
                break;
            case AgentType.GREEN:
                newSprite = green;
                break;
            case AgentType.RED:
                newSprite = red;
                break;
            case AgentType.YELLOW:
                newSprite = yellow;
                break;
        }

        GetComponentInChildren<SpriteRenderer>().sprite = newSprite;
    }
}

public enum AgentType { BLUE, GREEN, RED, YELLOW };
