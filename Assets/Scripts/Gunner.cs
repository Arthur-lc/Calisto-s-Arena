using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform[] gunPoints;

    private float timeSinceShot = 0;
    private int currentGun = 0;

    private void Start() {
        Debug.Log(gunPoints.Length);
    }

    private void Update() {
        timeSinceShot += Time.deltaTime;
        if (timeSinceShot > fireRate)
        {
            Shoot();
            timeSinceShot = 0;
        }
    }

    private void Shoot() {
        GameObject newProjectile = Instantiate(projectile, gunPoints[currentGun].position, transform.rotation);
        currentGun++;
        if (currentGun >= gunPoints.Length)
            currentGun = 0;
    }
}
