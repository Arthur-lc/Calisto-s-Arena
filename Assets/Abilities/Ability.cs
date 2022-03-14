using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public float cooldownTime;
    public float activeTime;
    public int lvl = 1;
    [TextArea] public string description = "place holder";
    [System.NonSerialized] public GameObject arrow;

    [Tooltip("Hide the Arrow wnhen ability is active")]
    public bool hideArrow = false;

    private void Awake() {
        lvl = 1;
    }

    public virtual void Activate(GameObject parent) {
        arrow = parent.GetComponent<MovementController>().pointingArrow;
        if (hideArrow) {
            arrow.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public virtual void onReady() {}
    public virtual void onCooldown() {
        if (hideArrow)
            arrow.GetComponent<SpriteRenderer>().enabled = true;
    }
}
