using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Obstacle prefabs info")]
    [SerializeField] GameObject metalObstaclePref;
    [SerializeField] GameObject stoneObstaclePref;
    [SerializeField] GameObject woodObstaclePref;

    [Header("Obstacle spawn info")]
    [SerializeField] float obstacleSpawnDuration;
    [SerializeField] float obstacleSpawnX;
    [SerializeField] float obstacleSpawnYRange;
    float obstacleSpawnTimer;

    [Header("Game score info")]
    int currentScore;

    [NonSerialized] public bool gamePause;
    [NonSerialized] public bool isPlaying;

    void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    void Start()
    {
        UI.instance.UpdateScoreUI(currentScore);

        isPlaying = false;
        UI.instance.GameStartUI(!isPlaying);
    }

    void Update()
    {
        GamePauseInput();

        if (isPlaying)
            ObstacleSpawnTimer();
    }

    void GamePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.P) && !gamePause)
            GamePause(true);
        else if (gamePause && Input.GetKeyDown(KeyCode.Space))
            GamePause(false);
    }

    void ObstacleSpawnTimer()
    {
        obstacleSpawnTimer -= Time.deltaTime;

        if (obstacleSpawnTimer < 0)
        {
            SpawnRandomObstacle();
            obstacleSpawnTimer = obstacleSpawnDuration;
        }
    }

    void GamePause(bool _pause)
    {
        gamePause = _pause;

        if (gamePause)
        {
            Time.timeScale = 0;
            UI.instance.GamePauseUI(_pause);
        }
        else
        {
            Time.timeScale = 1;
            UI.instance.GamePauseUI(_pause);
        }

    }

    void SpawnRandomObstacle()
    {
        GameObject obstacleToSpawn;
        float randomRange = UnityEngine.Random.Range(1, 101);

        if (randomRange <= 33)
            obstacleToSpawn = metalObstaclePref;
        else if (randomRange >= 66)
            obstacleToSpawn = stoneObstaclePref;
        else
            obstacleToSpawn = woodObstaclePref;

        Vector3 spawnPos = new Vector3(obstacleSpawnX, UnityEngine.Random.Range(-obstacleSpawnYRange, obstacleSpawnYRange));
        Instantiate(obstacleToSpawn, spawnPos, Quaternion.identity);
    }

    public void UpdateScore()
    {
        currentScore++;
        UI.instance.UpdateScoreUI(currentScore);
    }
}
