using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacles), 1, 1);
    }

    private void SpawnObstacles()
    {
        Destroy(Instantiate(obstacle, spawnPoints[0]), 5);
        Destroy(Instantiate(obstacle, spawnPoints[1]), 5);
        Destroy(Instantiate(obstacle, spawnPoints[2]), 5);
        Destroy(Instantiate(obstacle, spawnPoints[3]), 5);
        Destroy(Instantiate(obstacle, spawnPoints[4]), 5);
    }
}
