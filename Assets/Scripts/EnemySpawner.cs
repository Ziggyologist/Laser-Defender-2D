using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WavesConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WavesConfigSO currentWave;

    public WavesConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    IEnumerator SpawnEnemiesWaves()
    {
        bool isLooping = true;
        do
        {
            foreach (WavesConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                //isLooping = false;
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping == true);

    }
}
