using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] Transform reactorToPoint;

    private void FixedUpdate()
    {
        if (reactorToPoint == null)
            Destroy(gameObject);
        else
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, AimScript.GetAngleToAim(reactorToPoint.position, transform.position, -90)));
    }
}
