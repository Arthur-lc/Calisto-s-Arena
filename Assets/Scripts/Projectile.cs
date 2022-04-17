using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : DealsDamage
{
    public float speed = 1f;
    [System.NonSerialized] public Rigidbody2D rb;
    [System.NonSerialized] public int abilitylvl = 1;
    
    protected virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.rotation * Vector2.up) * speed;
        Invoke("Exclude", 5f);
    }

    protected virtual void Exclude() {
        Destroy(this.gameObject);
    }
}