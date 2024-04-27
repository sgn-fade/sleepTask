
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private GameObject[] enemyPrefabs;
    private float m_spawnTimer = 1f;

    private void Start()
    {
        Invoke(nameof(SpawnEnemy), m_spawnTimer);
    }
    
    private void OnEnable()
    {
        Player.Player.OnPlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        Player.Player.OnPlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        gameObject.SetActive(false);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
        Invoke(nameof(SpawnEnemy), m_spawnTimer);
    }
}
