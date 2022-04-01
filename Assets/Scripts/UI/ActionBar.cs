using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    public bool isDragging = false;
    public bool isDragingAbilityNew = false;
    public bool wasPurchaseEffected;
    private Ability draggingAbility;
    private int draggingAbilityLvl;

    [Header("UX / turotial")]
    public GameObject ttrlChoseSlot;
    public GameObject ttrlChoseCard;
    public GameObject btnPanel;
    public Button btnContinue;

    private void OnEnable() {
        Events.onBuyingAbility.AddListener(InitiatingPurchase);
        Events.onPurchaseEffected.AddListener(PurchaseEffected);
    }

    private void OnDisable() {
        Events.onBuyingAbility.RemoveListener(InitiatingPurchase);
        Events.onPurchaseEffected.RemoveListener(PurchaseEffected);
    }

    private void Start() {
        
    }

    private void Update() {
        ttrlChoseSlot.SetActive(isDragging);
        ttrlChoseCard.SetActive(!wasPurchaseEffected);
        if(GameManager.Instance.state == GameState.BuyingAbility && wasPurchaseEffected)
        {
            btnPanel.SetActive(true);
            btnContinue.interactable = !isDragging;
        }
    }

    public void OnSlotSelected(SkillSlot slot) {
        if (isDragging)
        {
            Ability aux = slot.ability;
            int auxLvl = slot.abilityHolder.abilityLevel;
            if (isDragingAbilityNew)
            {
                wasPurchaseEffected = true;
                isDragingAbilityNew = false;
                Events.onPurchaseEffected.Invoke();
            }
            
            if (!slot.isEmpty)
            {
                slot.UpdateAbility(draggingAbility, draggingAbilityLvl);
                draggingAbility = aux;
                draggingAbilityLvl = auxLvl;
            }
            else
            {
                slot.UpdateAbility(draggingAbility, draggingAbilityLvl);
                isDragging = false;
            }
        }
        else
        {
            if (!slot.isEmpty)
            {
                isDragging = true;
                draggingAbility = slot.ability;
                draggingAbilityLvl = slot.abilityHolder.abilityLevel;
                slot.UpdateAbility(null);
            }
        }
    }

    public void AddNewAbility(Ability ability) {
        if (ability == null)
        {
            isDragging = false;
            isDragingAbilityNew = false;
        }
        else
        {
            isDragging = true;
            isDragingAbilityNew = true;
        }
        draggingAbility = ability;
        draggingAbilityLvl = 1;
    }

    private void InitiatingPurchase() {
        Debug.Log("Buying new ability");
        wasPurchaseEffected = false;
        btnPanel.SetActive(false);
    }

    private void PurchaseEffected() {
        wasPurchaseEffected = true;
    }
}
