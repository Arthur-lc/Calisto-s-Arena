using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    public bool isDragging = false;
    private bool isAbilityNew = false;
    public bool wasPurchaseEffected;
    private Ability draggingAbility;
    private int draggingAbilityLvl;

    private void OnEnable() {
        Events.onBuyingAbility.AddListener(InitiatingPurchase);
    }

    private void OnDisable() {
        Events.onBuyingAbility.RemoveListener(InitiatingPurchase);
    }

    public void OnSlotSelected(SkillSlot slot) {
        if (isDragging)
        {
            Ability aux = slot.ability;
            int auxLvl = slot.abilityHolder.abilityLevel;
            if (isAbilityNew)
            {
                wasPurchaseEffected = true;
                //draggingAbilityLvl = 1;
            }
            
            if (!slot.isEmpty)
            {
                slot.UpdateAbility(draggingAbility, draggingAbilityLvl);
                draggingAbility = aux;
                draggingAbilityLvl = auxLvl;
            }
            else
            {
                slot.UpdateAbility(draggingAbility, draggingAbilityLvl);
                isDragging = false;
            }
        }
        else
        {
            if (!slot.isEmpty)
            {
                isDragging = true;
                draggingAbility = slot.ability;
                draggingAbilityLvl = slot.abilityHolder.abilityLevel;
                slot.UpdateAbility(null);
            }
        }
    }

    public void AddNewAbility(Ability ability) {
        isDragging = true;
        isAbilityNew = true;
        draggingAbility = ability;
        draggingAbilityLvl = 1;
    }

    private void InitiatingPurchase() {
        Debug.Log("Buying new ability");
        wasPurchaseEffected = false;
    }
}
