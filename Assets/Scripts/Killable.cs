using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] private float hp = 1f;
    HordeSystem hordeSystem;

    private void Start() {
        hordeSystem = FindObjectOfType<HordeSystem>();
        Events.onEnemySpawned.Invoke();
    }

    public void TakeDamage(float damageTaken) {
        if (hp > 0)
            hp -= damageTaken;
        if (hp <= 0)
            Die();
    }

    public void Die() {
        Events.onEnemyDied.Invoke();
        Destroy(this.gameObject);
    }
}
