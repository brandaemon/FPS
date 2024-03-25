using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float radius;
    public float spawnInterval;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        Vector3 spawnPosition = transform.position + new Vector3(x, 0, z);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
