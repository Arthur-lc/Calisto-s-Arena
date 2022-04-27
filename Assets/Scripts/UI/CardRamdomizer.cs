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
        if (GameManager.Instance.waveNumber > 0)
        {
            Debug.Log("BRUNO DO CRL CALA A BOCA");
            bool haveDamageAbility = false;
            int[] abilityIds = new int[3];
            while (abilityIds[0] == abilityIds[1] || abilityIds[1] == abilityIds[2] || abilityIds[0] == abilityIds[2] || !haveDamageAbility)
            {
                haveDamageAbility = false;
                Debug.Log("haveDamageAbility" + haveDamageAbility);
                for (int i = 0; i < cards.Length; i++)
                {
                    abilityIds[i] = Random.Range(0, abilities.Length);
                    while (!isAblityLvlUnderMax(abilities[abilityIds[i]]))
                    {
                        abilityIds[i] = Random.Range(0, abilities.Length);  
                    }
                    if (abilities[abilityIds[i]].type == Ability.Types.damage)
                        haveDamageAbility = true;
                }
            }

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].UpdateCard(abilities[abilityIds[i]]);
            }
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
