using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public void Destroy(float delay)
    {
        Destroy(gameObject, delay);
    }
}
