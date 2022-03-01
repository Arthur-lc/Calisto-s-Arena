using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;

    enum AbilityState {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;
    public KeyCode key; //input to activate the ability
    
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if(Input.GetKeyDown(key)) {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
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
