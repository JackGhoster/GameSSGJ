using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 500;
    private float _horizontalInput = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (_rb != null)
        {
            _rb.velocity = new Vector2( _horizontalInput * _speed * Time.deltaTime, _rb.velocity.y);
        }
    }
    private void Update()
    {
        _horizontalInput = InputManager.Instance.HorizontalInput;
    }

    private void CheckForMovement()
    {
        //print("checking if it's standing)");
        if (_horizontalInput == 0)
        {
            EventManager.Instance.StoppedMoving();
        }
    }

    private void OnEnable()
    {
        InvokeRepeating("CheckForMovement", 0.2f, 0.2f);
    }
    private void OnDisable()
    {
        CancelInvoke("CheckForMovement");
    }

    
}
