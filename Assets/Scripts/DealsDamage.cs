using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamage : MonoBehaviour
{
    public LayerMask targetLayer;
    public string targetTag = "Enemy";
    public float damage;

    [Tooltip("numero de inimigos que serao atingidos (-1 para ignorar)")]
    public int piercing = -1;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        //if (other.TryGetComponent<Killable>(out Killable target) && other.gameObject.layer == (other.gameObject.layer | (1 << targetLayer))) {
        if (other.TryGetComponent<Killable>(out Killable target) && other.tag == targetTag) {
            target.TakeDamage(damage);
            piercing--;
            if (piercing == 0) {
                Destroy(this.gameObject);
            }
        }
    }
}
