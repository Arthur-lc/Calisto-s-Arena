using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamgePerTime : MonoBehaviour
{
    public string targetTag = "Enemy";
    public float damage;
    public float damageRate = 1f;
    public float timeSinceDamage = 0;

    private void Update() {
        timeSinceDamage += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (timeSinceDamage > damageRate)
        {
            if (other.TryGetComponent<Killable>(out Killable target) && other.tag == targetTag)
            {
                DealDamage(target);
                timeSinceDamage = 0;
            }
        }
    }

    public virtual void DealDamage(Killable target) {
        target.TakeDamage(damage);
    }
}
