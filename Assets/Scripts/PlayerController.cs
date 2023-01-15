using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movespeed;
    [SerializeField] private float _jumpHeight;
    private bool _isFinished;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private bool _isPlayerGrounded => _rigidbody.velocity.y == 0;

    public void SetFinish(bool isFinish) 
    {
        _animator.SetBool("IsFinish", isFinish);
        _isFinished = isFinish;
        _animator.SetBool("IsRunning", false);

    }
    private void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Move.performed += context => Move();

        _input.Player.Jump.performed += context => Jump();

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {

        Move();
        _animator.SetFloat("IsJumping", _rigidbody.velocity.y);



    }

    private void Move()
    {
        if (!_isFinished) 
        {
            var direction = _input.Player.Move.ReadValue<Vector2>();
            var magnitude = direction.sqrMagnitude;
            float scaledMoveSpeed = _movespeed * Time.deltaTime;

            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            transform.position += moveDirection * scaledMoveSpeed;
            _animator.SetBool("IsRunning", magnitude != 0);

        }
        
        
    }

    private void Jump()
    {
              

        if (_isPlayerGrounded)
        {
            _rigidbody.AddForce(_jumpHeight * Vector3.up, ForceMode.VelocityChange);
            


        }

    }


}
