
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int spawnRate = 2;
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
    private void OnEnable()
    {
        Player.OnPlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        Player.OnPlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        gameObject.SetActive(false);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[Random.Range(0, spawners.Length)],spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
    }
}
