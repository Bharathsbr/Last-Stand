using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera=Camera.main;
    }

    private void Update()
    {
        DestroyBullet();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<EnemyMovement>())
        {
            HealthController healthController=other.GetComponent<HealthController>();
            healthController.TakeDamage(10);
            Destroy(gameObject);
        }
    }

    private void DestroyBullet()
    {
        Vector2 bulletpos=_camera.WorldToScreenPoint(transform.position);
        if(bulletpos.x<0 || bulletpos.x>_camera.pixelWidth || bulletpos.y<0 || bulletpos.y>_camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
