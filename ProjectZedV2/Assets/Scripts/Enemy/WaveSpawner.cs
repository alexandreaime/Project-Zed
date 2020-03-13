using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public static Player player;

    //Waypoint
    private Transform spawnPoint;
    private int waypointIndex = 0;

    //Time
    private float countdown = 5f;
    public float timeBetweenWaves = 10f;
    public float timeBetweenSpawnEnemy = 2f;

    //Wave
    private int waveIndex = 0;
    public int waveIndexMax = 20;
    
    //Enemy
    public Enemy enemy;

    void Start()
    {
        spawnPoint = Waypoints.points[0];
    }
    
    void Update()
    {
        if (player == null)
        {
            EnemyList.RemoveAll();
        }
        else
        {
            if (countdown <= 0f)
            {
                if (waveIndex < waveIndexMax)
                {
                    Debug.Log("Waves");
                    StartCoroutine(SpawnWave());
                }
                countdown = timeBetweenWaves;
            }
            else
            {
                countdown -= Time.deltaTime;
            }
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
        enemy.Spawn(spawnPoint.position,spawnPoint.rotation);
    }
}