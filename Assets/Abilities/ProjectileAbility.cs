using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/Projectile")]
public class ProjectileAbility : Ability
{
    public float damage;
    public GameObject projectile;
    private GameObject newProjectile;

    public override void Activate(AbilityHolder holder) {
        base.Activate(holder);

        arrow = holder.GetComponent<MovementController>().pointingArrow;
        
        newProjectile = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation);
        newProjectile.SetActive(true);

        //make sure that the hability does damage
        if(newProjectile.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage)) {
            dealsDamage.damage = damage;
        }
    }
}
