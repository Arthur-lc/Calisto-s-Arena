using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public int maxLvl;
    public bool isPassive;
    public float cooldownTime;
    public float activeTime;
    public AudioClip sfx;
    [TextArea] public string description = "place holder";
    [TextArea] public string lvlUpDescription = "Don´t lvl Up this ability, it's not working properly";
    [System.NonSerialized] public GameObject arrow;

    [Tooltip("Hide the Arrow wnhen ability is active")]
    public bool hideArrow = false;

    public virtual void Activate(AbilityHolder holder) {
        arrow = holder.GetComponent<MovementController>().pointingArrow;
        if (hideArrow) {
            arrow.GetComponent<SpriteRenderer>().enabled = false;
        }

        AudioSource audioSource = holder.GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(.8f, 1.2f);
        audioSource.PlayOneShot(sfx);
    }

    public virtual void onReady() {}
    public virtual void onCooldown() {
        if (hideArrow)
            arrow.GetComponent<SpriteRenderer>().enabled = true;
    }
}
