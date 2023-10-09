using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePref;

    [Header("Obstacle spawn info")]
    [SerializeField] float obstacleSpawnDuration;
    [SerializeField] float obstacleSpawnX;
    [SerializeField] float obstacleSpawnYRange;
    float obstacleSpawnTimer;

    void Update()
    {
        obstacleSpawnTimer -= Time.deltaTime;

        if (obstacleSpawnTimer < 0)
        {
            SpawnObstacle();
            obstacleSpawnTimer = obstacleSpawnDuration;
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(obstacleSpawnX, Random.Range(-obstacleSpawnYRange, obstacleSpawnYRange));
        Instantiate(obstaclePref, spawnPos, Quaternion.identity);
    }
}
