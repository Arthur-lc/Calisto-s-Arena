using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform[] gunPoints;
    [SerializeField] private float range;

    private float timeSinceShot = 0;
    private int currentGun = 0;
    private Transform player;

    private void Start() {
        Debug.Log(gunPoints.Length);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update() {
        timeSinceShot += Time.deltaTime;
        if (timeSinceShot > fireRate && IsTargetInRange())
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

    private bool IsTargetInRange() {
        return (Vector3.Distance(transform.position, player.transform.position) < range);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
