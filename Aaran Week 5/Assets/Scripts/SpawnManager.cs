using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemy;
    public int EnemyIndex;
    private float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 2, 5);
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
        
    }
    void spawnEnemy()
    {
        int EnemyIndex = Random.Range(0, Enemy.Length);
        Instantiate(Enemy[EnemyIndex], GenerateSpawnPosition(), Enemy[EnemyIndex].transform.rotation);
    }


}
