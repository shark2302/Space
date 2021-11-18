using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public static Spawner solo;

    public GameObject[] PrefabEnemies;

    //интервалы возрождений
    public float EnemySpawnPerSecond = 0.5f;

    //отступы между врагами
    public float EnemyDefaultPadding = 1.5f;

    private BoundsChecker _boundsChecker;

    private void Awake()
    {
        if (solo == null)
        {
            solo = this;
        }
        else
        {
            Debug.LogError("Spawner has already created");
        }

        _boundsChecker = GetComponent<BoundsChecker>();
        Invoke("SpawnEnemy", 1f / EnemySpawnPerSecond);
    }

    public void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, PrefabEnemies.Length);
        GameObject go = Instantiate(PrefabEnemies[enemyIndex]);
        
        Vector3 position = Vector3.zero;
        var cameraHeigth = Camera.main.orthographicSize;
        var cameraWidth = cameraHeigth * Camera.main.aspect;

        float xMin = -cameraWidth + EnemyDefaultPadding;
        float xMax = cameraWidth - EnemyDefaultPadding;

        position.x = Random.Range(xMin, xMax);
        position.y = cameraHeigth - EnemyDefaultPadding;

        go.transform.position = position;
        
        Invoke("SpawnEnemy", 1f / EnemySpawnPerSecond);
    }
    void Update()
    {
        
    }
}
