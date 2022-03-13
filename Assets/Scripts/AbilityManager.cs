using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    AbilityHolder newAbiltyHolder;
    ActionBar actionBar;

    public List<AbilityHolder> abilityList = new List<AbilityHolder>();
    
    private void Start() {
        actionBar = FindObjectOfType<ActionBar>();
    }

    public void AddNewAbility(Ability ability, KeyCode key) {
        //TryGetComponent<AbilityHolder>(out AbilityHolder holder);
        //component
        if (FindHolder(ability, out AbilityHolder holder))
        {
            holder.ability.lvl++;
        }
        else
        {
            newAbiltyHolder = gameObject.AddComponent<AbilityHolder>();
        }
    }

    private bool FindHolder(Ability ability, out AbilityHolder holder) {
        // retorna o AbilityHolder que contem a habilidade
        foreach (var AHolder in abilityList)
        {
            if (AHolder.ability.name == ability.name)
            {
                holder = AHolder;
                return true;
            }
        }
        holder = null;
        return false;
    }

}
