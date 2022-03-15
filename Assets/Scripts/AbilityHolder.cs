using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] public Ability ability;
    [SerializeField] public KeyCode key; //input to activate the ability
    public int abilityLevel = 1;

    float cooldownTime;
    float activeTime;

    enum AbilityState {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;
    
    void Update()
    {
        if (FindObjectOfType<GameManager>().state == GameState.Playing && ability != null)
        {
            switch (state)
            {
                case AbilityState.ready:
                    if(Input.GetKeyDown(key)) {
                        ability.Activate(this);
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

    public void Upgrade() {
        abilityLevel++;

        foreach (var slot in FindObjectsOfType<SkillSlot>())
        {
            slot.Reload();
        }
    }
}
