using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBar : MonoBehaviour
{
    public PassiveSlot passiveSlot;
    public void AddNewAbility(Ability ability) {
        Debug.Log("aaaaaaaaaaaaaa");
        PassiveSlot newSlot = Instantiate(passiveSlot, transform);
        newSlot.Initiate();
        newSlot.UpdateAbility(ability);
    }
}
