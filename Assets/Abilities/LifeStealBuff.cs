using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/LifeStealBuff")]
public class LifeStealBuff : Ability
{
    int lvl = 0;
    int chance;

    private void OnEnable() {
        Events.onCauseDamage.AddListener(AplyEfect);
        Events.onReloadGame.AddListener(Reset);
        lvl = 0;
    }
    private void OnDisable() {
        Events.onCauseDamage.RemoveListener(AplyEfect);
        Events.onReloadGame.RemoveListener(Reset);
    }

    private void AplyEfect(float damage) {
        int random = Random.Range(0, 100);
        if (chance > random)
        {
            Debug.Log(chance + " > " + random);
            FindObjectOfType<PlayerKillable>().Heal(damage * 0.5f);
        }
        else
        {
            Debug.Log(chance + " < " + random);
        }
    }

    public override void Activate(AbilityHolder holder)
    {
        lvl = holder.abilityLevel;
        chance = lvl * 5;
    }

    private void Reset() {
        lvl = 0;
        chance = 0;
    }
}
