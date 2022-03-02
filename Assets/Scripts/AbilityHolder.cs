using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] public Ability ability;
    [SerializeField] public KeyCode key; //input to activate the ability

    float cooldownTime;
    float activeTime;

    enum AbilityState {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    public AbilityHolder(Ability newAbility, KeyCode newKey) {
        ability = newAbility;
        key = newKey;
    }
    
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if(Input.GetKeyDown(key)) {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                    Debug.Log("a");
                }

            break;
            case AbilityState.active:
                if (activeTime > 0) {
                    activeTime -= Time.deltaTime;
                }
                else {
                    state = AbilityState.cooldown;
                    ability.onCooldown();    
                }

            break;
            case AbilityState.cooldown:
                if (cooldownTime > 0) {
                    cooldownTime -= Time.deltaTime;
                }
                else {
                    state = AbilityState.ready;
                    ability.onReady();
                }

            break;
        }
    }
}
