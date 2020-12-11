using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Range(0f,10f)]
    [SerializeField] float parallaxMultiplayer;
    Transform cameraPos;
    Vector3 defaultPosition;
    void Start()
    {
        cameraPos = Camera.main.transform;
        defaultPosition = cameraPos.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovment = cameraPos.position - defaultPosition;
        transform.position += deltaMovment * parallaxMultiplayer;
        defaultPosition = cameraPos.position;
    }
}
