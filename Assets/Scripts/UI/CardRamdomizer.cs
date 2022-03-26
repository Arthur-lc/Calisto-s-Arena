using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRamdomizer : MonoBehaviour
{
    public Ability[] abilities;
    public Card[] cards;

    private void OnEnable() {
        Events.onBuyingAbility.AddListener(RandomizeCards);
    }

    private void OnDisable() {
        Events.onBuyingAbility.RemoveListener(RandomizeCards);
    }

    public void RandomizeCards() {
        foreach (Card card in cards)
        {
            int abilityNumber = Random.Range(0, abilities.Length);
            Debug.Log(isAbilityRepeated(abilities[abilityNumber]));
            while (isAbilityRepeated(abilities[abilityNumber]) || !isAblityLvlUnderMax(abilities[abilityNumber]))
            {
                abilityNumber = Random.Range(0, abilities.Length);
                Debug.Log(isAbilityRepeated(abilities[abilityNumber]));
            }
            card.UpdateCard(abilities[abilityNumber]);
        }
    }

    private bool isAbilityRepeated(Ability ability) {
        foreach (Card card in cards)
        {
            if (card.ability == ability)
            {
                return true;
            }
        }
        return false;
    }

    private bool isAblityLvlUnderMax(Ability ability) {
        if (ability.maxLvl == 0)
            return true;

        if (HaveAbility(ability, out AbilityHolder holder))
        {
            if (holder.abilityLevel < ability.maxLvl)
                return true;
            else
                return false;
        }
        return true;
    }

    private bool HaveAbility(Ability ability, out AbilityHolder abilityHolder) {
        foreach (var holder in FindObjectsOfType<AbilityHolder>())
        {
            if (holder.ability == ability)
            {
                abilityHolder = holder;
                return true;
            }
        }
        abilityHolder = null;
        return false;
    }
}
