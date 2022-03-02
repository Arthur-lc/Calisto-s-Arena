using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/Projectile")]
public class ProjectileAbility : Ability
{
    public float damage;
    public GameObject projectile;
    private GameObject newClone;

    public override void Activate(GameObject parent)
    {
        base.Activate(parent);

        arrow = parent.GetComponent<MovementController>().pointingArrow;
        
        newClone = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation);

        //make sure that the hability does damage
        if(newClone.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage)) {
            dealsDamage.damage = damage;
        }
    }
}
