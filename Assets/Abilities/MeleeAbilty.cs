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

    public override void Activate(AbilityHolder holder)
    {
        base.Activate(holder);
        
        clone = Instantiate(attackObjetct, arrow.transform.position, arrow.transform.rotation, holder.transform);

        //make shure that the hability does damage
        if(clone.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage)) {
            dealsDamage.damage = damage * holder.abilityLevel / 2;
        }

    }

    public override void onCooldown()
    {
        base.onCooldown();

        arrow.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(clone);
    }
}
