using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField]
    private float chanceToDrop;
    private CollectableSpawner spawner;

    private void Awake()
    {
        spawner=FindObjectOfType<CollectableSpawner>();
    }

    public void Spawn()
    {
        float chance=Random.Range(0f,1f);
        if(chanceToDrop>=chance)
        {
            spawner.SpawnCollectable(transform.position);
        }
    }
}
