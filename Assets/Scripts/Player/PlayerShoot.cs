using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform gun_Offset;

    [SerializeField]
    private float timeBetweenShots;
    private float lastFireTime;
    private bool singleFire;

    private bool firingContinuously;
    void Update()
    {
        if(firingContinuously || singleFire)
        {
            float timeFromLastFire=Time.time-lastFireTime;

            if(timeFromLastFire>=timeBetweenShots)
            {
                FireBullet();
                lastFireTime=Time.time;
                singleFire=false;
            }
        }
       
        
    }

    private void FireBullet()
    {
            GameObject bullet=Instantiate(bulletPrefab,gun_Offset.position,transform.rotation);
            Rigidbody2D _rigidbody=bullet.GetComponent<Rigidbody2D>();
            _rigidbody.velocity=transform.up*speed;
    }

    private void OnFire(InputValue inputValue)
    {
        firingContinuously=inputValue.isPressed;
        if(inputValue.isPressed)
        {
            singleFire=true;
        }
    }
}
