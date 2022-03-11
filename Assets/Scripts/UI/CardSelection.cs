using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelection : MonoBehaviour
{
    public GameObject cardBar;
    public GameObject keyPrompt;
    public Card selectedCard;

    public enum State
    {
        selectCard, selectKey, playing
    }

    State state = State.selectCard;

    private void OnEnable() {
        Events.onCardSelected.AddListener(cardSelected);
        Events.onKeySelected.AddListener(keySelected);
    }

    private void OnDisable() {
        Events.onCardSelected.RemoveListener(cardSelected);
        Events.onKeySelected.RemoveListener(keySelected);
    }

    public void cardSelected(Card card) {
        selectedCard = card;
        keyPrompt.SetActive(true);
    }

    public void keySelected(KeyCode key) {
        selectedCard.SelectCard(key);
        gameObject.SetActive(false);
        Events.newWave.Invoke();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowKeyPrompt(false);
        }
    }

    private void ShowKeyPrompt(bool value) {
        if (value)
            keyPrompt.SetActive(true);
        else
            keyPrompt.SetActive(false);
    }



    /*
    private void Update() {
        if (state == State.selectKey) {
            /* if (Input.GetKeyDown(KeyCode.Escape)) {      
                UpdateState(State.selectCard);
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                UpdateState(State.playing);
            } 
        }     
    }

    
    private void UpdateState(State newState) {
        state = newState;
        switch (state)
        {
            case State.selectCard:
                Debug.Log("Chose a card");
                keyPrompt.SetActive(false);
                cardBar.SetActive(true);
                
                break;
            case State.selectKey:
                Debug.Log("Chose a key");
                keyPrompt.SetActive(true);
                
                break;
            case State.playing:
                Debug.Log("Play");
                
                gameObject.SetActive(false);

                break;
        }
    }

    public void NextState() {
        if (state == State.selectCard)
            UpdateState(State.selectKey);
        else if (state == State.selectKey)
            UpdateState(State.playing);
    }
    */
}
