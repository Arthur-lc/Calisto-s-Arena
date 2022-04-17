using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    protected override void Start() {
        
    }
    private void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.rotation * Vector2.up) * speed;
        Invoke("Exclude", 10f);
    }

    protected override void Exclude() {
        gameObject.SetActive(false);
    }
}
