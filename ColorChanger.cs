using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour//defines the current color of the player and the bullets
{
    public static AgentType currentColor;
    Queue<AgentType> colors = new Queue<AgentType>();

    private void Start()
    {
        //Enqueue every color existent
        colors.Enqueue(AgentType.RED);
        colors.Enqueue(AgentType.YELLOW);
        colors.Enqueue(AgentType.BLUE);
        colors.Enqueue(AgentType.GREEN);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))//right mouse button change the current color for the next
            ChangeColor();
    }

    void ChangeColor()//puts the first color of the queue in the last place and sets it as the "currentColor"
    {
        AgentType color = colors.Dequeue();
        currentColor = color;
        colors.Enqueue(color);
        OnColorChanged.Invoke();
    }

    public static Color GetCurrentColor()//get a enum andtranslate to color - return
    {
        Color newColor = Color.white;

        switch (currentColor)
        {
            case AgentType.BLUE:
                newColor = new Color(0,255,227);
                break;
            case AgentType.GREEN:
                newColor = Color.green;
                break;
            case AgentType.RED:
                newColor = Color.red;
                break;
            case AgentType.YELLOW:
                newColor = Color.yellow;
                break;
        }

        return newColor;
    }


    public static UnityEvent OnColorChanged = new UnityEvent();
}
