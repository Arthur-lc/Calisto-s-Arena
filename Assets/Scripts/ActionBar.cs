using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    [SerializeField] private GameObject abiltyIcon;
    public void addNewAbilty(Ability ability) {
        GameObject newIcon;
        newIcon = Instantiate(abiltyIcon, this.transform);
        newIcon.GetComponent<Image>().sprite = ability.Icon;
    }

}
