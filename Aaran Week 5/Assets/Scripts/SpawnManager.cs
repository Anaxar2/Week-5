using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header ("Enemy")]
    public GameObject[] Enemy;
    public GameObject Boss;
    public int EnemyIndex;
    public int enemyCount;
    public int waveNumber = 1;

    [Header ("PowerUps")]
    public GameObject[] powerUps;
    public int powerUpsIndex;

    private float spawnRange = 10;


    // Start is called before the first frame update
    void Start()
    {
        powerUpSpawn();
        spawnEnemy(waveNumber);
    }
    private Vector3 GenerateSpawnPosition()
    {
     float spawnPosX = Random.Range(-spawnRange, spawnRange);
     float spawnPosZ = Random.Range(-spawnRange, spawnRange);
     Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
     return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
     enemyCount = FindObjectsOfType<EnemyMovement>().Length;
     if (enemyCount == 0)
        {
            waveNumber++; spawnEnemy(waveNumber);
            powerUpSpawn();
            if(waveNumber % 3 == 0)
            {
                spawnBoss();
            }
        }
    }
    void spawnEnemy(int enemiesToSpawn)
    {   
        for(int i = 0; i < enemiesToSpawn; i++) 
        {
         int EnemyIndex = Random.Range(0, Enemy.Length);
         Instantiate(Enemy[EnemyIndex], GenerateSpawnPosition(), Enemy[EnemyIndex].transform.rotation);
        }
        
    }
    void powerUpSpawn()
    {
        int powerUpsIndex = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[powerUpsIndex], GenerateSpawnPosition(), powerUps[powerUpsIndex].transform.rotation);
    }
    void spawnBoss()
    {
        
        {
            Instantiate(Boss, GenerateSpawnPosition(), Boss.transform.rotation);
        }
    }

}
