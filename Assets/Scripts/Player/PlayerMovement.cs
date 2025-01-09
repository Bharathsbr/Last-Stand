using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float rotationSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 movement;
    private Vector2 smoothMovement;
    private Vector2 smoothMovementVelocity;
    private Camera _camera;

    [SerializeField]
    private float screenBorder;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera=Camera.main;
        _animator=GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerVelocity();
        PlayerRotation();
        isMoving();
    }

    private void isMoving()
    {
        bool ismove=movement!=Vector2.zero;
        _animator.SetBool("Move",ismove);
    }

    private void PlayerVelocity()
    {
        smoothMovement = Vector2.SmoothDamp(smoothMovement, movement, ref smoothMovementVelocity, 0.1f);
        _rigidbody.velocity = smoothMovement * speed;
        PreventPlayerFromGoingOffscreen();
    }

    private void PreventPlayerFromGoingOffscreen()
    {
        Vector2 screenPosition=_camera.WorldToScreenPoint(transform.position);

        if((screenPosition.x<screenBorder && _rigidbody.velocity.x<0) || (screenPosition.x>_camera.pixelWidth-screenBorder && _rigidbody.velocity.x>0))
        {
            _rigidbody.velocity=new Vector2(0,_rigidbody.velocity.y);
        }
        if((screenPosition.y<screenBorder && _rigidbody.velocity.y<0) || (screenPosition.y>_camera.pixelHeight-screenBorder && _rigidbody.velocity.y>0))
        {
            _rigidbody.velocity=new Vector2(_rigidbody.velocity.x,0);
        }
    }
    private void PlayerRotation()
    {
        if(movement!=Vector2.zero)
        {
            Quaternion target=Quaternion.LookRotation(transform.forward,smoothMovement);
            Quaternion rotation=Quaternion.RotateTowards(transform.rotation,target,rotationSpeed*Time.deltaTime);
            _rigidbody.MoveRotation(rotation);
        }
    }
    private void OnMove(InputValue inputValue)
    {
        movement=inputValue.Get<Vector2>();
    }
}
