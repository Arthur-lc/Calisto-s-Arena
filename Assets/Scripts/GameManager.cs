using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    
    private GameObject cardSelection;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        cardSelection = GameObject.Find("CardSelection");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.K))
            UpdateGameState(GameState.Playing);
        if (Input.GetKeyDown(KeyCode.L))
            UpdateGameState(GameState.BuyingAbility);
    }

    public void UpdateGameState(GameState newState) {
        state = newState;

        switch (newState)
        {
            case GameState.BuyingAbility:
                cardSelection.SetActive(true);
                Events.onBuyingAbility.Invoke();
            
            break;
            case GameState.Playing:
                cardSelection.SetActive(false);
                Events.onStartWave.Invoke();
            
            break;
            default:

            break;
        }
    }
}

public enum GameState {
    Playing,
    BuyingAbility,
}