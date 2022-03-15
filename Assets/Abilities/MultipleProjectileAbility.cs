using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/MultipleProjectile")]
public class MultipleProjectileAbility : Ability
{
    public float damage;
    public GameObject projectile;
    public float spread;

    public override void Activate(AbilityHolder holder) {
        base.Activate(holder);

/*
        arrow = holder.GetComponent<MovementController>().pointingArrow;
        float facingRotation = Mathf.Atan2(arrow.transform.rotation.y, arrow.transform.rotation.x) * Mathf.Deg2Rad;
        float startRotation = facingRotation + spread / 2f;
        float angleIncrease = spread / ((float)holder.abilityLevel - 1f);
        
        for (int i = 0; i < holder.abilityLevel; i++)
        {
            float tempRot = startRotation - angleIncrease * i;
            GameObject newProjectile = Instantiate(projectile, arrow.transform.position, Quaternion.Euler(0f, 0f, tempRot));
            Debug.Log(Quaternion.Euler(0f, 0f, tempRot));

            float addedOffset = (i - (holder.abilityLevel / 2) * spread);

            Quaternion arrowDir = arrow.transform.rotation;
            Quaternion newRot = Quaternion.Euler(arrowDir.x, arrowDir.y, arrowDir.z + addedOffset);
            GameObject newProjectile = Instantiate(projectile,arrow.transform.position, newRot);


            if(newProjectile.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage)) {
                dealsDamage.damage = damage;
            }
        }
*/
/*

        Quaternion startRotation = arrow.transform.rotation * Quaternion.Euler(0, 0, spread / 2);
        Quaternion angleIncrease = Quaternion.Euler(0, 0, spread / holder.abilityLevel - 1);

        for (int i = 0; i < holder.abilityLevel; i++)
        {
            //Quaternion rot = Quaternion.Euler(0, 0, (spread / 2)) * Quaternion.Inverse((angleIncrease)) * i);
            GameObject newProjectile = Instantiate(projectile, arrow.transform.position, 
                arrow.transform.rotation * Quaternion.Euler(0, 0, (spread / holder.abilityLevel) * i) * Quaternion.Inverse(Quaternion.Euler(0, 0, spread/2)));
                //arrow.transform.rotation * Quaternion.Euler(0, 0, ((spread / holder.abilityLevel - 1) * i) - spread);
            Debug.Log(i);
        }
*/
        int isEven = 1;
        int projectileCount = holder.abilityLevel;
        GameObject newProjectile;
        if (holder.abilityLevel % 2 != 0)
        {
            isEven = 0;
            projectileCount--;
            newProjectile = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation);
            if(newProjectile.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage)) {
                    dealsDamage.damage = damage;
            }    
        }

        for (int i = 1; i <= projectileCount/2; i++)
        {
            newProjectile = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation * Quaternion.Euler(0, 0, -10 * i + 5 * isEven));
            if(newProjectile.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage1)) {
                dealsDamage1.damage = damage;
            }
            newProjectile = Instantiate(projectile, arrow.transform.position, arrow.transform.rotation * Quaternion.Euler(0, 0, +10 * i - 5 * isEven));
            if(newProjectile.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage2)) {
                dealsDamage2.damage = damage;
            }
        }


    }
}
