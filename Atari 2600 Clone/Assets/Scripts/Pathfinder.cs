using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveSO waveSO;
    List<Transform> waypoints;
    int waypointIndex = 0;
    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        waveSO = enemySpawner.GetCurrentWave();
    }
    void Start()
    {
        waypoints = waveSO.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float speed = waveSO.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);

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

