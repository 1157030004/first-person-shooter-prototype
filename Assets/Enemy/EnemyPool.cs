using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0,50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnRate = 5f;

    GameObject[] enemies;

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        
    }

    void PopulatePool()
    {
        enemies = new GameObject[poolSize];

        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = Instantiate(enemyPrefab, transform);
            enemies[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            if(!enemies[i].activeInHierarchy)
            {
                enemies[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
