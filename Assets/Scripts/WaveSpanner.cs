using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpanner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public int enemyMore = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 8f;
    private float countdown = 5f;

    private int waveNumber = 0;

    void Update()
    {
        //int a = 4;
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            //return;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];
        wave.count += enemyMore;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            System.Console.WriteLine("Enemy created " + i);
            yield return new WaitForSeconds(1 / wave.rate);
        }
        waveNumber++;

        if (waveNumber == waves.Length)
        {
            waveNumber = 0;
            enemyMore++;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    public int getWaveNumber()
    {
        return waveNumber;
    }
}
