using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HordeSystem : MonoBehaviour
{
    [System.Serializable] public struct EnemyGroup
    {
        public int quantity;
        public GameObject enemy;
    }

    [System.Serializable] public class Wave
    {
        public EnemyGroup[] enemyGroups;
    }
    
    public GameManager gameManager;

    [Tooltip("Area where enemies will spawn")]
    public float radius;

    [SerializeField] public Wave[] waves;
    private int currentWaveNumber = 0;
    private Wave currentWave;

    public int enemyCount = 0;

    private void OnEnable() {
        Events.onStartWave.AddListener(NewWave);
        Events.onEnemyDied.AddListener(DecreaseEnemyCount);
        Events.onEnemySpawned.AddListener(IncreaseEnemyCount);

    }

    private void OnDisable() {
        Events.onStartWave.RemoveListener(NewWave);
        Events.onEnemyDied.RemoveListener(DecreaseEnemyCount);
        Events.onEnemySpawned.RemoveListener(IncreaseEnemyCount);
    }

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
        enemyCount += transform.childCount;
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

    public void NewWave() {
        currentWave = waves[currentWaveNumber];
        foreach(var enemyGroup in currentWave.enemyGroups) 
        {
            for (int i = 0; i < enemyGroup.quantity; i++)
            {
                GameObject newEnemy = Instantiate(enemyGroup.enemy, this.transform);
                newEnemy.GetComponent<Enemy>().Spawn(radius);
            }
        }
        currentWaveNumber++;
    }

    public void EndWave() {
        Debug.Log("end fase");
        Invoke("activateCardSelection", .5f);
    }

    private void activateCardSelection() {
        gameManager.UpdateGameState(GameState.BuyingAbility);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Vector3.zero, radius);
    }

    public void AddEnemy() {
        enemyCount++;
        Debug.Log(enemyCount);
    }

    public void SubtractEnemy() {
        /*enemyCount--;
        Debug.Log(enemyCount);
        if (enemyCount == 0) {
            EndWave();
        }*/

        if(!GameObject.FindGameObjectWithTag("Enemy"))
        {
            EndWave();
        }
    }
}