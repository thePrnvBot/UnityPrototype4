using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    private float spawnRange = 9f;
    private int waveNumber = 1;
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateRandomSpawn(), powerupPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateRandomSpawn(), powerupPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) 
        {
            Instantiate(enemyPrefab, GenerateRandomSpawn(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomSpawn()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
