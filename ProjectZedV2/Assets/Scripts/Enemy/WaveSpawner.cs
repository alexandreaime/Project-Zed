using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [Header("Waypoint départ")]
    private Transform spawnPoint;
    private int waypointIndex = 0;

    [Header("Prefab")]
    public Transform enemyPrefab;

    [Header("Time")]
    private float countdown = 2f;
    public float timeBetweenWaves = 5f;
    public float timeBetweenSpawnEnemy = 0.5f;

    [Header("Wave")]
    private int waveIndex = 0;
    public int waveIndexMax = 20;


    void Start()
    {
        spawnPoint = Waypoints.points[0];
    }


    void Update()
    {
        if (countdown <= 0f)
        {
            if (waveIndex < waveIndexMax)
            {
                StartCoroutine(SpawnWave());
            }
            countdown = timeBetweenWaves;
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }


    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            ChangeWaypoints();

            yield return new WaitForSeconds(timeBetweenSpawnEnemy);
        }
    }


    void ChangeWaypoints()
    {
        if (waypointIndex < Waypoints.points.Length -1)
        {
            waypointIndex++;
            spawnPoint = Waypoints.points[waypointIndex];
        }
        else
        {
            waypointIndex = 1;
        }
    }


    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
