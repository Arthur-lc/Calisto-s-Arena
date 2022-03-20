using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/PiercingProjectile")]
public class PiercingProjectileAbility : Ability
{
    public float damage;
    public GameObject projectile;
    private GameObject newProjectile;

    public override void Activate(AbilityHolder holder) {
        base.Activate(holder);

        arrow = holder.GetComponent<MovementController>().pointingArrow;
        
        newProjectile = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation);
        newProjectile.GetComponent<Projectile>().damage = damage;
        newProjectile.GetComponent<Projectile>().piercing = holder.abilityLevel;
    }
}
