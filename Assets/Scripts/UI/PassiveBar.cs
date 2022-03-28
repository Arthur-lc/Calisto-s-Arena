using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBar : MonoBehaviour
{
    public PassiveSlot passiveSlot;
    public GameObject ttrlPassiveAbilities;

    private void OnEnable() {
        Events.onStartWave.AddListener(ShowTTRL);
    }

    private void OnDisable() {
        Events.onStartWave.RemoveListener(ShowTTRL);
    }
    public void AddNewAbility(Ability ability) {
        Debug.Log("aaaaaaaaaaaaaa");
        PassiveSlot newSlot = Instantiate(passiveSlot, transform);
        newSlot.Initiate();
        newSlot.UpdateAbility(ability);
        ttrlPassiveAbilities.SetActive(true);
    }

    public void ShowTTRL() {
        ttrlPassiveAbilities.SetActive(false);
    }
}
