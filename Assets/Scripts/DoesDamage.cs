using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoesDamage : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6)
        Debug.Log(other.gameObject.name);
    }
}
