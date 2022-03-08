using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircler : Enemy
{
    public float rotationSpeed;

    public override void Update() {
        base.Update();

        Vector2 point;
        point = -transform.position.normalized;
        rb.velocity = Vector2.Perpendicular(point) * speed;
        transform.Rotate(0f, 0f, rotationSpeed, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("oi");  
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }
    }
}
