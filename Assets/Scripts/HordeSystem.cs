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
    
    public GameObject cardSelection;

    [Tooltip("Area where enemies will spawn")]
    public float radius;

    [SerializeField] public Wave[] waves;
    private int currentWaveNumber = 0;
    private Wave currentWave;
    private AbilityManager abilityManager;

    [System.NonSerialized] public int enemyCount;

    private void OnEnable() {
        Events.newWave.AddListener(NewWave);

    }

    private void OnDisable() {
        Events.newWave.RemoveListener(NewWave);
    }

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        abilityManager = player.GetComponent<AbilityManager>();
    }

    public void NewWave() {
        currentWave = waves[currentWaveNumber];
        foreach(var enemyGroup in currentWave.enemyGroups) 
        {
            for (int i = 0; i < enemyGroup.quantity; i++)
            {
                GameObject newEnemy = Instantiate(enemyGroup.enemy);
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
        cardSelection.SetActive(true);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Vector3.zero, radius);
    }

    public void AddEnemy() {
        enemyCount++;
    }

    public void SubtractEnemy() {
        enemyCount--;
        if (enemyCount == 0) {
            EndWave();
        }
    }
}
