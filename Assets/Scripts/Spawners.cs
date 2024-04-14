using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnRate = 1;
    private double m_spawnTimer = 0;

    private void Update()
    {
        m_spawnTimer += Time.deltaTime;

        if (m_spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            m_spawnTimer = 0;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
    }
}
