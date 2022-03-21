using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    public float damage;
    [Tooltip("numero de inimigos que serao atingidos (-1 para ignorar)")]
    public int piercing = -1;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (transform.rotation * Vector2.up) * speed;
        Invoke("Exclude", 10f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<Killable>(out Killable target) && other.tag == "Enemy") { 
            target.TakeDamage(damage);
            piercing--;
            if (piercing <= 0) {
                Destroy(this.gameObject);
            }
        }
    }

    private void Exclude() {
        Destroy(this.gameObject);
    }
}