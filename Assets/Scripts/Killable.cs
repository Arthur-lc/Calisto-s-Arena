using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] public float hp = 1f;
    [System.NonSerialized] public float maxHp;

    private void Start() {
        maxHp = hp;
    }

    public virtual void TakeDamage(float damageTaken) {
        ImpulseManager.Instance.Shake(damageTaken / maxHp);
        hp -= damageTaken;

        if (hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die() {
        Events.onEnemyDied.Invoke();
        GameObject particle = GameManager.Pool.GetPooledObject();
        particle.transform.position = this.transform.position;
        particle.SetActive(true);
        Destroy(this.gameObject);
    }
}
