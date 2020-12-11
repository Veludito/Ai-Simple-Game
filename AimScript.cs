using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public static float GetAngleToAim(Vector2 target, Vector2 itself, float angleOffset)//Returns the angle where should look
    {
        Vector2 lookDirection = target - itself;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + angleOffset;
        return angle;
    }
}
