using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WavesConfigSO", menuName = "Scriptable Objects/WavesConfigSO")]
public class WavesConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float spawnRate = 1f;
    [SerializeField] float spawnTimeVariance = 0.5f;
    [SerializeField] float minimumSpawnTime = 0.2f;



    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        if (index < 0 || index >= enemyPrefabs.Count)
        {
            Debug.LogError("Index out of range");
            return null;
        }
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(spawnRate - spawnTimeVariance, spawnRate + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
        public float GetMoveSpeed() {
        return moveSpeed;
    }
}
