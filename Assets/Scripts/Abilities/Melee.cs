using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Melee")]
public class Melee : Ability
{
    public float damage;
    public GameObject attackObjetct;

    private GameObject clone;
    private GameObject arrow;

    public override void Activate(GameObject parent)
    {
        base.Activate(parent);

        arrow = parent.GetComponent<MovementController>().pointingArrow;
        
        clone = Instantiate(attackObjetct, arrow.transform.position, arrow.transform.rotation, parent.transform);
        arrow.GetComponent<SpriteRenderer>().enabled = false; //hide arrow
        if(clone.TryGetComponent<DoesDamage>(out DoesDamage doesDamage)) {
            doesDamage.damage = damage;
        }
    }

    public override void onCooldown()
    {
        base.onCooldown();

        arrow.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(clone);
    }
}
