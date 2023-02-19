using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int initialEnemyCount;
    public float spawnInterval;
    public int enemyCountIncrease;

    private int currentEnemyCount;

    private void Start()
    {
        currentEnemyCount = initialEnemyCount;
        InvokeRepeating("SpawnEnemies", spawnInterval, spawnInterval);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < currentEnemyCount; i++)
        {
            Vector3 spawnPoistion = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
            Instantiate(enemyPrefab, spawnPoistion, Quaternion.identity);
        }
        currentEnemyCount += enemyCountIncrease;
    }

}
