using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    private bool isDragging = false;
    private Ability draggingAbility;

    public void OnSlotSelected(SkillSlot slot) {
        Debug.Log("clicou no slot");
        if (isDragging)
        {
            Ability aux = slot.ability;
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
        draggingAbility = ability;
        Debug.Log("Agora ta draggind, abilidade: " + ability);
    }
}
