using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassiveSlot : MonoBehaviour
{
    public Ability ability;
    public PassiveHolder passiveHolder;

    [Header("References")]
    public Image iconHolder;
    public TextMeshProUGUI lvlText;
    public TextMeshProUGUI timeText;
    public Image cooldownFX;

    public void Initiate() {
        Debug.Log("start");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        passiveHolder = player.AddComponent<PassiveHolder>();
    }

    private void Update() {
        if (ability.cooldownTime != -1 && passiveHolder.state == AbilityHolder.AbilityState.cooldown && GameManager.Instance.state == GameState.Playing)
        {
            timeText.text = ((int)passiveHolder.cooldownTime + 1).ToString();
            cooldownFX.fillAmount = passiveHolder.cooldownTime / (ability.cooldownTime - passiveHolder.cooldownModifier);
        }
        else
        {
            timeText.text = "";
            cooldownFX.fillAmount = 0;
        }
    }

    public void UpdateAbility(Ability newAbility, int newAbilityLvl = 1) {
        Debug.Log("PassiveSlot UpdateAbility " + newAbility);
        ability = newAbility;
        passiveHolder.abilityLevel = 1;
        Reload();
    }

    public void Reload() {
        passiveHolder.ability = ability;
        iconHolder.sprite = ability.icon;
        lvlText.text = passiveHolder.abilityLevel.ToString();
    }
}
