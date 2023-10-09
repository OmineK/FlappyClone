using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject metalObstaclePref;
    [SerializeField] GameObject stoneObstaclePref;
    [SerializeField] GameObject woodObstaclePref;

    [Header("Obstacle spawn info")]
    [SerializeField] float obstacleSpawnDuration;
    [SerializeField] float obstacleSpawnX;
    [SerializeField] float obstacleSpawnYRange;
    float obstacleSpawnTimer;

    void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    void Update()
    {
        obstacleSpawnTimer -= Time.deltaTime;

        if (obstacleSpawnTimer < 0)
        {
            SpawnRandomObstacle();
            obstacleSpawnTimer = obstacleSpawnDuration;
        }
    }

    void SpawnRandomObstacle()
    {
        GameObject obstacleToSpawn;
        float randomRange = Random.Range(1, 101);

        if (randomRange <= 33)
            obstacleToSpawn = metalObstaclePref;
        else if (randomRange >= 66)
            obstacleToSpawn = stoneObstaclePref;
        else
            obstacleToSpawn = woodObstaclePref;

        Vector3 spawnPos = new Vector3(obstacleSpawnX, Random.Range(-obstacleSpawnYRange, obstacleSpawnYRange));
        Instantiate(obstacleToSpawn, spawnPos, Quaternion.identity);
    }
}
