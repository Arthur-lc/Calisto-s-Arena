using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] public float hp = 1f;

    public virtual void TakeDamage(float damageTaken) {
        if (hp > 0)
            hp -= damageTaken;
        if (hp <= 0)
            Die();
    }

    public virtual void Die() {
        Events.onEnemyDied.Invoke();
        Destroy(this.gameObject);
    }
}
