using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/LifeStealBuff")]
public class LifeStealBuff : Ability
{
    int lvl;
    private void OnEnable() {
        Events.onCauseDamage.AddListener(AplyEfect);
        lvl = 0;
    }
    private void OnDisable() {
        Events.onCauseDamage.AddListener(AplyEfect);
    }

    private void AplyEfect(float damage) {
        Debug.Log(lvl);
        FindObjectOfType<PlayerKillable>().Heal(damage * lvl * 0.1f);
    }

    public override void Activate(AbilityHolder holder)
    {
        lvl = holder.abilityLevel;
        Debug.Log("lvl agora e " + lvl);
    }
}
