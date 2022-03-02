using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float cooldownTime;
    public float activeTime;
    public GameObject arrow;

    public virtual void Activate(GameObject parent) {
        arrow = parent.GetComponent<MovementController>().pointingArrow;
        arrow.GetComponent<SpriteRenderer>().enabled = false;
    }
    public virtual void onReady() {}
    public virtual void onCooldown() {
        arrow.GetComponent<SpriteRenderer>().enabled = true;
    }
}
