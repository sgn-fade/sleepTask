using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawners : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;

    [SerializeField] private GameObject enemyPrefab;
    // private void Start()
    // {
    //     for(var i = 0; i < 5; i++)
    //     {
    //         Instantiate(enemyPrefab,spawners[Random.Range(0, spawners.Length)].transform.position, Quaternion.identity);
    //
    //     }
    // }
}
