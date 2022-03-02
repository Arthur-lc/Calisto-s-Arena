using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] private float hp = 1f;

    public void TakeDamage(float damageTaken) {
        hp -= damageTaken;
        if (hp <= 0)
            Die();
    }

    public void Die() {
        Destroy(this.gameObject);
    }
}
