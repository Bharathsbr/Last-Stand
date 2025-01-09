using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour,ICollectableBehavior
{
    [SerializeField]
    private float health;
    public void onCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(health);
    }
}
