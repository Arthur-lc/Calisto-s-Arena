using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    private bool isDragging = false;
    private bool isAbilityNew = false;
    public bool wasPurchaseEffected;
    private Ability draggingAbility;

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
            if (isAbilityNew)
                wasPurchaseEffected = true;
            
            if (!slot.isEmpty)
            {
                slot.UpdateAbility(draggingAbility);
                draggingAbility = aux;
            }
            else
            {
                slot.UpdateAbility(draggingAbility);
                isDragging = false;
            }
        }
        else
        {
            if (!slot.isEmpty)
            {
                isDragging = true;
                draggingAbility = slot.ability;
                slot.UpdateAbility(null);
            }
        }
    }

    public void AddNewAbility(Ability ability) {
        isDragging = true;
        isAbilityNew = true;
        draggingAbility = ability;
    }

    private void InitiatingPurchase() {
        Debug.Log("Buying new ability");
        wasPurchaseEffected = false;
    }
}
