using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WavesConfigSO wavesConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }
    void Start()
    {
        wavesConfig = enemySpawner.GetCurrentWave();
        waypoints = wavesConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = wavesConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
