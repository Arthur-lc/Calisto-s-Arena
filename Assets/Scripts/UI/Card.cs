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
    public GameObject pasiveTxt;
    private ActionBar actionBar;
    private PassiveBar passiveBar;

    private void OnEnable() {
        Events.onPurchaseEffected.AddListener(notInteractable);
        Events.onBuyingAbility.AddListener(Interactable);
    }

    private void OnDisable() {
        Events.onPurchaseEffected.RemoveListener(notInteractable);
        Events.onBuyingAbility.RemoveListener(Interactable);
    }

    void Start() {
        actionBar = FindObjectOfType<ActionBar>();
        passiveBar = FindObjectOfType<PassiveBar>();


        UpdateCard(ability);
    }

    public void UpdateCard(Ability newAbility) {
        if (newAbility == null)
        {
            Debug.LogWarning("Ability is empty");
        }
        else
        {
            ability = newAbility;
            image.sprite = newAbility.icon;
            title.text = newAbility.name;
            if (HaveAbility())
                description.text = newAbility.lvlUpDescription;
            else
                description.text = newAbility.description;
            
            pasiveTxt.SetActive(ability.isPassive);

        }

    }

    public void Clicked() {
        Debug.Log("clicou na carta da " + ability);
        if (!actionBar.wasPurchaseEffected && !actionBar.isDragging)
        {
            if (HaveAbility(out AbilityHolder holder))
            {
                holder.UpgradeAbility();
                Events.onPurchaseEffected.Invoke();
            }
            else
            {
                if (ability.isPassive)
                {
                    Debug.Log("habilidade passiva");
                    passiveBar.AddNewAbility(ability);
                    Events.onPurchaseEffected.Invoke();
                }
                else
                {
                    actionBar.AddNewAbility(ability);
                }
            }
        }
        else if (actionBar.isDragging && actionBar.isDragingAbilityNew)
        {
            if (HaveAbility(out AbilityHolder holder))
            {
                holder.UpgradeAbility();
                actionBar.AddNewAbility(null);
                Events.onPurchaseEffected.Invoke();
            }
        }
    }

    private bool HaveAbility(out AbilityHolder abilityHolder) {
        foreach (var holder in FindObjectsOfType<AbilityHolder>())
        {
            if (holder.ability == ability)
            {
                abilityHolder = holder;
                return true;
            }
        }
        abilityHolder = null;
        return false;
    }
    private bool HaveAbility() {
        foreach (var holder in FindObjectsOfType<AbilityHolder>())
        {
            if (holder.ability == ability)
            {
                return true;
            }
        }
        return false;
    }

    private void Interactable() { GetComponent<Button>().interactable = true;}
    private void notInteractable() {GetComponent<Button>().interactable = false;}
}
