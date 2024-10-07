using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;

    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;
    public int health; 
    public int CurrentWaveIndex = 0;

    private bool readyToCountDown;
    private void Start()
    {
        readyToCountDown = true;
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {
        if (CurrentWaveIndex >= waves.Length)
        {
            return;
        }
        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }


        if (countdown <= 0)
        {
            countdown = waves[CurrentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }

        if (waves[CurrentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            CurrentWaveIndex++;
        }

    }
    private IEnumerator SpawnWave()
    {
        if (CurrentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[CurrentWaveIndex].enemies.Length; i++)
            {

                EnemyAI enemyai = Instantiate(waves[CurrentWaveIndex].enemies[i], spawnPoint.transform);
                enemyai.transform.SetParent(spawnPoint.transform);
                yield return new WaitForSeconds(waves[CurrentWaveIndex].timeToNextEnemy);
            }
        }
    }
    [System.Serializable]
    public class Wave
    {
        public EnemyAI[] enemies;
        public float timeToNextEnemy;
        public float timeToNextWave;

        [HideInInspector] public int enemiesLeft;
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        if (health <= 0) Invoke(nameof(DestorySpawner), 0.5f);
        else
        {
            // get hit animaiton 
        }

    }

    public void DestorySpawner()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position); 
        Destroy(gameObject);
       

    }

}
