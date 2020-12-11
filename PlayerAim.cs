using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Camera main;
    Vector3 mousePos;
    Rigidbody2D rb;

    private void Start()
    {
        main = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, AimScript.GetAngleToAim(mousePos, transform.position, -90)));
    }
}
