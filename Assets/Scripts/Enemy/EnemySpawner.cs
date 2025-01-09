using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minTime;

    [SerializeField]
    private float maxTime;

    private float timeUntilSpawn;

    private void Update()
    {
        timeUntilSpawn-=Time.deltaTime;
         if(timeUntilSpawn<=0)
        {
            Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            Spawn();
        }
    }
    private void Spawn()
    {
        timeUntilSpawn=Random.Range(minTime,maxTime);
       
    }

}
