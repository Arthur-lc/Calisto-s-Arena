using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSystem : MonoBehaviour
{
    public Ability ability; //gambiarra
    public KeyCode key; //gambiarra
    AbilityManager abilityManager;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        abilityManager = player.GetComponent<AbilityManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            abilityManager.AddNewAbility(ability, key);
        }
    }
}
