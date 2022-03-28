using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveHolder : AbilityHolder
{
    /*[SerializeField] public Ability ability;
    public int abilityLevel = 1;

    public float cooldownTime;
    public float cooldownModifier = 0;
    */

    private void OnEnable() {
        Events.onStartWave.AddListener(ResetCooldown);
    }

    private void OnDisable() {
        Events.onStartWave.RemoveListener(ResetCooldown);
    }

    private void Start() {
        if (ability.cooldownTime == -1)
        {
            ability.Activate(this);
        }
    }

    public override void Update()
    {
        if (GameManager.Instance.state == GameState.Playing && ability != null && ability.cooldownTime != -1)
        {
            switch (state)
            {
                case AbilityState.ready:
                    ability.Activate(this);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;

                break;
                case AbilityState.active:
                    if (activeTime > 0) {
                        activeTime -= Time.deltaTime;
                    }
                    else {
                        state = AbilityState.cooldown;
                        ability.onCooldown(); 
                        cooldownTime = ability.cooldownTime - cooldownModifier;
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

    public override void ResetCooldown() {
        cooldownTime = ability.cooldownTime - cooldownModifier;
        state = AbilityState.cooldown;
    }

    public override void UpgradeAbility()
    {
        abilityLevel++;
        foreach (var slot in FindObjectsOfType<PassiveSlot>())
        {
            slot.Reload();
        }

        if (ability.cooldownTime == -1)
            ability.Activate(this);
        state = AbilityState.active;
    }
}
