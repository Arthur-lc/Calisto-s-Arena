using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    List<AbilityHolder> abilities = new List<AbilityHolder>();

    // FOR TESTES ONLY
    // FOR TESTES ONLY

    public Ability ability1;
    public KeyCode keyCode;

    // FOR TESTES ONLY
    // FOR TESTES ONLY

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
            AddNewAbility(ability1, keyCode);
    }
    public void AddNewAbility(Ability ability, KeyCode key) {
        abilities.Add( new AbilityHolder(ability, key));
    }
}
