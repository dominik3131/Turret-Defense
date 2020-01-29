using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpanner : MonoBehaviour
{
    public int enemiesInWave = 2;
    public static int enemiesAlive = 0;

    public List<Wave> waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 8f;

    private float countdown = 5f;
    private int waveNumber = 0;
    private void Awake()
    {
        enemiesAlive = 0;
    }
    void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        float posibility = Random.Range(0f, 1f);
        List<Wave> possibleWaves = waves.FindAll(wave => 
        wave.startingWaved <= waveNumber && wave.spawnProbability >= posibility
        );

        for (int i = 0; i < enemiesInWave; i++)
        {
            int index = Random.Range(0, possibleWaves.Count);
            Wave wave = possibleWaves[index];
            SpawnEnemy(wave.enemy);
            if (wave.spawnProbability <= 1.0f) {
                wave.spawnProbability += 0.05f;
            }
            yield return new WaitForSeconds(1 / wave.rate);
        }

        waveNumber++;
        if (waveNumber % 3 == 0)
        {
            enemiesInWave += 1;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }

    public int getWaveNumber()
    {
        return waveNumber;
    }

    public void removeAllEnemies()
    {
        enemiesAlive = 0;
    }

}
