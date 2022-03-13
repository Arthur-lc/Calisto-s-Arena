using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public KeyCode keyCode;
    public Ability ability;
    public bool isEmpty = true;

    [Header("References")]
    public Image iconHolder;
    public Sprite baseImage;
    private AbilityHolder abilityHolder;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        abilityHolder = player.AddComponent<AbilityHolder>();
        abilityHolder.key = keyCode;

        if (ability == null)
        {
            isEmpty = true;
            iconHolder.sprite = baseImage;
        }
        else
        {
            iconHolder.sprite = ability.icon;
            isEmpty = false;
            abilityHolder.ability = ability;
        }
    }
    
    public void UpdateAbility(Ability newAbility) {
        ability = newAbility;
        if (newAbility == null)
        {
            isEmpty = true;
            iconHolder.sprite = baseImage;
        }
        else
        {
            iconHolder.sprite = ability.icon;
            isEmpty = false;
            abilityHolder.ability = newAbility;
        }
    }

    public void Clicked() {
        Debug.Log("clicou");
        FindObjectOfType<ActionBar>().OnSlotSelected(this);
    }
}
