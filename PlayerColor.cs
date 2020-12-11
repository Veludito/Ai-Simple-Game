using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite red, yellow, blue, green;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ColorChanger.OnColorChanged.AddListener(SetPlayerColor);
    }

    public void SetPlayerColor()
    {
        Sprite newSprite = red;

        switch (ColorChanger.currentColor)
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

        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
