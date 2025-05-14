using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WavesConfigSO currentWave;

    public WavesConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
        }
    }
}
