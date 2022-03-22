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
    public TextMeshProUGUI timeText;

    private AbilityHolder abilityHolder;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        abilityHolder = player.AddComponent<AbilityHolder>();
        abilityHolder.ability = ability;
        abilityHolder.key = keyCode;
        Reload();
    }

    private void Update() {
        if (abilityHolder.state == AbilityHolder.AbilityState.cooldown && GameManager.Instance.state == GameState.Playing)
            timeText.text = ((int)abilityHolder.cooldownTime).ToString();
        else
        {
            timeText.text = "";
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
            abilityHolder.ability = null;
            iconHolder.sprite = baseImage;
            lvlText.text = "";
        }
        else
        {
            isEmpty = false;
            abilityHolder.ability = ability;
            iconHolder.sprite = ability.icon;
            lvlText.text = abilityHolder.abilityLevel.ToString();
        }
    }

    public void Clicked() {
        Debug.Log("clicou");
        FindObjectOfType<ActionBar>().OnSlotSelected(this);
    }
}