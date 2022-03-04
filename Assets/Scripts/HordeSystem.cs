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
    
    public Ability ability; //gambiarra
    public KeyCode key; //gambiarra

    [Tooltip("Area where enemies will spawn")]
    public float radius;

    [SerializeField] public Wave[] waves;
    private int currentWaveNumber = 0;


    private Wave currentWave;
    private AbilityManager abilityManager;

    private void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        abilityManager = player.GetComponent<AbilityManager>();
    }

    void Update()
    {
        // gabiarra
        if (Input.GetKeyDown(KeyCode.K)) {
            EndWave();
            NewWave();
        }
        // gambiarra
    }

    private void NewWave() {
        currentWave = waves[currentWaveNumber];
        foreach(var enemyGroup in currentWave.enemyGroups) 
        {
            for (int i = 0; i < enemyGroup.quantity; i++)
            {
                GameObject newEnemy = Instantiate(enemyGroup.enemy);
                newEnemy.GetComponent<Enemy>().Spawn(radius);

                /*
                Vector2 enemyPosition = RandomPolar(radius);
                
                newEnemy.transform.position = enemyPosition;
                */
            }
        }
        currentWaveNumber++;
    }

    private void EndWave() {
        Debug.Log("end fase");
        abilityManager.AddNewAbility(ability, key);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Vector3.zero, radius);
    }
}
