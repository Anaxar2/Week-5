using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawn : MonoBehaviour
{
    public GameObject[] powerUps;
    public int powerUpsIndex;
    private float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("spawnPowerUps", 5, 10);   
    }
    private Vector3 spawnPosition()
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
    void spawnPowerUps()
    {
     int powerUpsIndex = Random.Range(0, powerUps.Length);
     Instantiate(powerUps[powerUpsIndex], spawnPosition(), powerUps[powerUpsIndex].transform.rotation);
    }
    
}
