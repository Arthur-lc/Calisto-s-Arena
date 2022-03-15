using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    public KeyCode keyCode;
    public Ability ability;
    public bool isEmpty = true;

    [Header("References")]
    public Image iconHolder;
    public TextMeshProUGUI lvlText;
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
        Reload();
    }

    public void Reload() {
        if (ability == null)
        {
            isEmpty = true;
            iconHolder.sprite = baseImage;
        }
        else
        {
            isEmpty = false;
            iconHolder.sprite = ability.icon;
            lvlText.text = abilityHolder.abilityLevel.ToString();
        }
    }

    public void Clicked() {
        Debug.Log("clicou");
        FindObjectOfType<ActionBar>().OnSlotSelected(this);
    }
}
