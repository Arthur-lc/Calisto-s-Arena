using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] public Ability ability;
    [SerializeField] public KeyCode key; //input to activate the ability
    public int abilityLevel = 1;

    public float cooldownTime;
    public float activeTime;

    public enum AbilityState {
        ready,
        active,
        cooldown
    }
    public AbilityState state = AbilityState.ready;

    private void OnEnable() {
        Events.onStartWave.AddListener(NewWave);
    }

    private void OnDisable() {
        Events.onStartWave.RemoveListener(NewWave);
    }

    private void Start() {
        
    }

    private void NewWave() {
        cooldownTime = 0;
    }

    
    void Update()
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
                        cooldownTime = ability.cooldownTime;   
                    }

                break;
                case AbilityState.cooldown:
                    if (cooldownTime > 0) {
                        cooldownTime -= Time.deltaTime;
                    }
                    else {
                        state = AbilityState.ready;
                        //cooldownTime = ability.cooldownTime;
                        ability.onReady();
                    }

                break;
            }
        }
    }

    public void UpgradeAbility() {
        abilityLevel++;

        foreach (var slot in FindObjectsOfType<SkillSlot>())
        {
            slot.Reload();
        }
    }
}
