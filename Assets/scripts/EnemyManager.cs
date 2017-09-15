using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int countEnemies = 0;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    private int spawnPointIndex;
    const int MAX_ENEMIES = 10;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if (countEnemies < MAX_ENEMIES)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            countEnemies++;
        }
        else
        {
            DestroyEnemy();
        }
        
    }

    void DestroyEnemy()
    {
        //GameObject.DestroyImmediate(enemy, true);
        countEnemies--;
    }

}
