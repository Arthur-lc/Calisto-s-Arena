using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/MeleeAbilty")]
public class MeleeAbilty : Ability
{
    /*
        Essencialmente uma habilidade melle intancia um objeto como filho
        esse objeto é enccaregado de, por exemplo, causar dano
    */

    public float damage;
    public GameObject attackObjetct;

    private GameObject clone;

    public override void Activate(GameObject parent)
    {
        base.Activate(parent);
        
        clone = Instantiate(attackObjetct, arrow.transform.position, arrow.transform.rotation, parent.transform);
         //hide arrow

        //make shure that the hability does damage
        if(clone.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage)) {
            dealsDamage.damage = damage;
        }
    }

    public override void onCooldown()
    {
        base.onCooldown();

        arrow.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(clone);
    }
}
