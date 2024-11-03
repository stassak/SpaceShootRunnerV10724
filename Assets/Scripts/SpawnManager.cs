using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPref;

    private float startSpawnDelay = 2f;
    private float repeatSpawning = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startSpawnDelay, repeatSpawning);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomEnemy()
    {
            int enemyIndex = Random.Range(0,enemyPref.Length);
            Vector3 spawnEnPosition = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));

            Instantiate(enemyPref[enemyIndex], spawnEnPosition, enemyPref[enemyIndex].transform.rotation);

    }
}
