using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    AbilityHolder newAbiltyHolder;
    ActionBar actionBar;
    
    private void Start() {
        actionBar = FindObjectOfType<ActionBar>();
    }

    public void AddNewAbility(Ability ability, KeyCode key) {
        newAbiltyHolder = gameObject.AddComponent<AbilityHolder>();
        newAbiltyHolder.ability = ability;
        newAbiltyHolder.key = key;

        actionBar.addNewAbilty(ability);
    }
}
