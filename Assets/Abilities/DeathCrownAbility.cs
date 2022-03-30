using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Passives/MultipleProjectile")]
public class DeathCrownAbility : Ability
{
    public float damage;
    public GameObject projectile;
    private AbilityHolder abilityHolder;

    private void OnEnable() {
        Events.onStartWave.AddListener(LvlUp);
    }
    private void OnDisable() {
        Events.onStartWave.RemoveListener(LvlUp);
    }

    public override void Activate(AbilityHolder holder)
    {
        base.Activate(holder);
        abilityHolder = holder;

        for (int i = 0; i < 12; i++)
        {
            GameObject newProjectile = Instantiate(projectile, holder.transform.position, Quaternion.Euler(0, 0, 30 * i));
            if(newProjectile.TryGetComponent<DealsDamage>(out DealsDamage dealsDamage1)) {
                dealsDamage1.damage = damage;
            }
        }
    }

    private void LvlUp() {
        if (abilityHolder)
        {
            abilityHolder.cooldownModifier = -6f / Mathf.Sqrt(abilityHolder.abilityLevel) + 6f;
            Debug.Log("coolDown " + abilityHolder.cooldownModifier);
        }
    }
}
