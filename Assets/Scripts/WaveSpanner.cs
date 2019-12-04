using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WaveSpanner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 8f;
    private float countdown = 5f;

    private int waveNumber = 0;

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1);
        }

        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    public int getWaveNumber()
    {
        return waveNumber;
    }
}
