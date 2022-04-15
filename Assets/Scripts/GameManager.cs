using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static ObjectPool Pool;
    public GameState state;
    
    private GameObject cardSelection;
    private ActionBar actionBar;
    [SerializeField] private GameOver gameOverScreen;
    public int waveNumber = 0;

    private void Awake() {
        Instance = this;
        Pool = GetComponent<ObjectPool>();
    }

    private void Start() {
        cardSelection = GameObject.Find("CardSelection");
        actionBar = FindObjectOfType<ActionBar>();
        UpdateGameState(GameState.BuyingAbility);
        Events.onReloadGame.Invoke();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.K) && actionBar.wasPurchaseEffected)
            UpdateGameState(GameState.Playing);
        if (Input.GetKeyDown(KeyCode.P))
            UpdateGameState(GameState.BuyingAbility);
    }

    public void UpdateGameState(GameState newState) {
        state = newState;

        switch (newState)
        {
            case GameState.BuyingAbility:
                cardSelection.SetActive(true);
                Events.onBuyingAbility.Invoke();
                Time.timeScale = 0;
                CleanProjectiles();
            
            break;
            case GameState.Playing:
                cardSelection.SetActive(false);
                Events.onStartWave.Invoke();
                Time.timeScale = 1;
            
            break;
            case GameState.GameOver:
                gameOverScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
            
            break;
            default:

            break;
        }
    }

    public void Playing(){
        UpdateGameState(GameState.Playing);
    }

    public void CleanProjectiles() {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }
}

public enum GameState {
    Playing,
    BuyingAbility,
    GameOver
}
