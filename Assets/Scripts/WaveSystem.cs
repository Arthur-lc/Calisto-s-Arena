using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject[] enemies;
    public float radius = 2.54f;

    [Header("Just Debug")]
    public int waveNumber = -1;
    public int enemyCount = 0;

    private void OnEnable() {
        Events.onStartWave.AddListener(StartNewWave);
        Events.onEnemyDied.AddListener(DecreaseEnemyCount);
        Events.onEnemySpawned.AddListener(IncreaseEnemyCount);

    }

    private void OnDisable() {
        Events.onStartWave.RemoveListener(StartNewWave);
        Events.onEnemyDied.RemoveListener(DecreaseEnemyCount);
        Events.onEnemySpawned.RemoveListener(IncreaseEnemyCount);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            waveNumber = 20;
        }
    }

    private void StartNewWave() {
        for (int e = 0; e < enemies.Length; e++)
        {
            if (waveNumber >= e * 5)
            {
                if (e >= 2) // ta hard coded mas eu n sei como fazer diferente
                {
                    Debug.Log("torre");
                    for (int i = 0; i < 1 + (waveNumber % 5); i++)
                    {
                        SpawnEnemy(enemies[e]);
                    }
                }
                else
                {
                    for (int i = 0; i < 3 + (waveNumber % 5); i++)
                    {
                        SpawnEnemy(enemies[e]);
                    }
                }
            }
        }
    }

    public void EndWave() {
        Debug.Log("end fase");
        waveNumber++;
        Invoke("activateCardSelection", .5f);
    }

    private void activateCardSelection() {
        GameManager.Instance.UpdateGameState(GameState.BuyingAbility);
    }

    private void SpawnEnemy(GameObject enemy) {
        GameObject newEnemy = Instantiate(enemy, this.transform);
        newEnemy.GetComponent<Enemy>().Spawn(radius);
    }

    private void IncreaseEnemyCount() {
        enemyCount++;
    }

    private void DecreaseEnemyCount() {
        enemyCount--;

        if(enemyCount == 0)
        {
            EndWave();
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Vector3.zero, radius);
    }
}
