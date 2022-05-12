using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] public Ability ability;
    [SerializeField] public KeyCode key; //input to activate the ability
    public int abilityLevel = 1;

    public float cooldownTime;
    public float cooldownModifier = 0;
    public float activeTime;

    public enum AbilityState {
        ready,
        active,
        cooldown
    }
    public AbilityState state = AbilityState.ready;

    private void OnEnable() {
        Events.onBuyingAbility.AddListener(ResetCooldown);
    }

    private void OnDisable() {
        Events.onBuyingAbility.RemoveListener(ResetCooldown);
    }

    private void Start() {
        ResetCooldown();
    }

    public virtual void ResetCooldown() {
        cooldownTime = 0;
    }

    
    public virtual void Update()
    {
        if (GameManager.Instance.state == GameState.Playing && ability != null)
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

    public virtual void UpgradeAbility() {
        abilityLevel++;

        foreach (var slot in FindObjectsOfType<SkillSlot>())
        {
            slot.Reload();
        }
    }
}
