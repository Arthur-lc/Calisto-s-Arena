using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/LifeStealBuff")]
public class LifeStealBuff : Ability
{
    int lvl;
    int chance;

    private void OnEnable() {
        Events.onCauseDamage.AddListener(AplyEfect);
        lvl = 0;
    }
    private void OnDisable() {
        Events.onCauseDamage.RemoveListener(AplyEfect);
    }

    private void AplyEfect(float damage) {
        int random = Random.Range(0, 100);
        if (chance > random)
            FindObjectOfType<PlayerKillable>().Heal(damage * 0.5f);
    }

    public override void Activate(AbilityHolder holder)
    {
        lvl = holder.abilityLevel;
        chance = lvl * 5;
    }
}
