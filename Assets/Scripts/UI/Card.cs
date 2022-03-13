using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    public Ability ability;
    public Image image;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    private void OnEnable() {
        
    }

    void Start() {
        image.sprite = ability.icon;
        title.text = ability.name;
        description.text = ability.description;
    }

    public void Clicked() {
        Debug.Log("clicou na carta da " + ability);
        FindObjectOfType<ActionBar>().AddNewAbility(ability);
    }

    /*public void SelectCard(KeyCode key) {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        AbilityManager abilityManager = FindObjectOfType<AbilityManager>();
        abilityManager.AddNewAbility(ability, key);
    }*/
}
