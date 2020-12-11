using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeBetweenShoots = 0.7f;
    float currentTime;
    bool shooting;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            shooting = true;

        if (Input.GetMouseButtonUp(0))
            shooting = false;

        if (currentTime <= 0)
        {
            Shoot();
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        if (shooting)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            currentTime = timeBetweenShoots;
        }
    }
}
