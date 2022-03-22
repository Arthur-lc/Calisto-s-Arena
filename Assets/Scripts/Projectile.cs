using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : DealsDamage
{
    public float speed = 1f;
    private Rigidbody2D rb;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.rotation * Vector2.up) * speed;
        Invoke("Exclude", 10f);
    }

    private void Exclude() {
        Destroy(this.gameObject);
    }
}