using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerControl : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] objects;
    private int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

    private void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, 2f);
    }

    public void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, objects.Length);
            Instantiate(objects[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }

}
