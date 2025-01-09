using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private ICollectableBehavior collectableBehavior;

    private void Awake() {
        collectableBehavior=GetComponent<ICollectableBehavior>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player=other.GetComponent<PlayerMovement>();
        if(player!=null)
        {
            collectableBehavior.onCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
