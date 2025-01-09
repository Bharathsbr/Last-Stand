using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;
    private PlayerAwarness playerAwarness;
    private Rigidbody2D _rigidbody;

    private Vector2 targetDirection;
    private float timeToChange;
    private Camera _camera;
    [SerializeField]
    private float screenBorder;

    [SerializeField]
    private float obstacleRadius;
    [SerializeField]
    private float obstacleDistance;

    [SerializeField]
    private LayerMask layerMask;

    private RaycastHit2D[] obstacles;
    private float cooldown;
    private Vector2 obstacleAvoidanceDistance;

    
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAwarness=GetComponent<PlayerAwarness>();
        targetDirection=transform.up;
        _camera=Camera.main;
        obstacles=new RaycastHit2D[10];
    }
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        MoveTowardsTarget();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionnChange();
        HandlePlayerTargetting();
        HandleObstacles();
        HandleEnemyOffscreen();
    }

    private void HandleEnemyOffscreen()
    {
        Vector2 screenPosition=_camera.WorldToScreenPoint(transform.position);

        if((screenPosition.x<screenBorder && targetDirection.x<0) || (screenPosition.x>_camera.pixelWidth-screenBorder && targetDirection.x>0))
        {
            targetDirection=new Vector2(-targetDirection.x,targetDirection.y);
        }
        if((screenPosition.y<screenBorder && targetDirection.y<0) || (screenPosition.y>_camera.pixelHeight-screenBorder && targetDirection.y>0))
        {
            targetDirection=new Vector2(targetDirection.x,-targetDirection.y);
        }
    }

    private void HandleRandomDirectionnChange()
    {
        timeToChange-=Time.deltaTime;
        if(timeToChange<=0)
        {
            float angleChange=Random.Range(-90f,90f);
            Quaternion rot=Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection=rot*targetDirection;
            timeToChange=Random.Range(1f,5f);
        }
    }

    private void HandlePlayerTargetting()
    {
        if(playerAwarness.awareOfPlayer)
        {
            targetDirection=playerAwarness.directionToPlayer;
        }
    }

    private void HandleObstacles()
    {
        cooldown-=Time.deltaTime;
        var filter=new ContactFilter2D();
        filter.SetLayerMask(layerMask);
        int noc=Physics2D.CircleCast(transform.position,obstacleRadius,transform.up,filter,obstacles,obstacleDistance);
        for(int i=0;i<noc;i++)
        {
            var obstacle=obstacles[i];
            if(obstacle.collider.gameObject==gameObject)
            {
                continue;
            }
            if(cooldown<=0)
            {
                obstacleAvoidanceDistance=obstacle.normal;
                cooldown=0.5f;
            }
            var targetrot=Quaternion.LookRotation(transform.forward,obstacleAvoidanceDistance);
            var rot=Quaternion.RotateTowards(transform.rotation,targetrot,rotationSpeed*Time.deltaTime);
            targetDirection=rot*Vector2.up;
            break;
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion target=Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation=Quaternion.RotateTowards(transform.rotation,target,rotationSpeed*Time.deltaTime);
        _rigidbody.SetRotation(rotation);
    }

    private void MoveTowardsTarget()
    {
         _rigidbody.velocity=transform.up*speed;
    }
}
