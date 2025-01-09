using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> collectablePrefabs;

    public void SpawnCollectable(Vector2 position)
    {
        int index=Random.Range(0, collectablePrefabs.Count);
        var selected=collectablePrefabs[index];
        Instantiate(selected,position,Quaternion.identity);
    }
}
