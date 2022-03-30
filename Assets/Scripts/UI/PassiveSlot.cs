using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassiveSlot : MonoBehaviour
{
    public Ability ability;

    [Header("References")]
    public Image iconHolder;
    public TextMeshProUGUI lvlText;
    public TextMeshProUGUI timeText;
    public PassiveHolder passiveHolder;

    public void Initiate() {
        Debug.Log("start");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        passiveHolder = player.AddComponent<PassiveHolder>();
    }

    private void Update() {
        if (ability.cooldownTime != 0 && passiveHolder.state == AbilityHolder.AbilityState.cooldown && GameManager.Instance.state == GameState.Playing)
            timeText.text = ((int)passiveHolder.cooldownTime + 1).ToString();
        else
        {
            timeText.text = "";
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
