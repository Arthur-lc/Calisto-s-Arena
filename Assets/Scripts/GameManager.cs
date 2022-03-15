using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;

    private void Awake() {
        Instance = this;
    }
    
    void Start()
    {
        //state = GameState.BuyingAbility;
    }

    public void UpdateGameState(GameState newState) {
        state = newState;
    }
}

public enum GameState {
    Playing,
    BuyingAbility,
}
