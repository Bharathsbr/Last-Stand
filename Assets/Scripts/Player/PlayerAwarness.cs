using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarness : MonoBehaviour
{
    public bool awareOfPlayer {get;private set;}
    
    [SerializeField]
    private float playerAwarnessDistance;

    public Vector2 directionToPlayer {get;private set;}

    private Transform player;

    private void Awake()
    {
        player=FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector2 enemyToPlayer=player.position-transform.position;
        directionToPlayer=enemyToPlayer.normalized;

        if(enemyToPlayer.magnitude<=playerAwarnessDistance)
        {
            awareOfPlayer=true;
        }
        else
        {
            awareOfPlayer=false;
        }
    }
}
