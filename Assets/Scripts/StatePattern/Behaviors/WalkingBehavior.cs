using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed = 1000;
    //private float _jumpForce = 7;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (_rb != null)
        {
            //print("walking");
            _rb.velocity = new Vector2(InputManager.Instance.WASDVector2.x * _speed * Time.deltaTime, _rb.velocity.y);
        }
    }

    private void CheckForMovement()
    {
        //print("checking if it's standing)");
        if (_rb.velocity.x == 0)
        {
            EventManager.Instance.StoppedMoving();
        }
    }

    private void OnEnable()
    {
        InvokeRepeating("CheckForMovement", 0.1f, 0.1f);
    }
    private void OnDisable()
    {
        CancelInvoke("CheckForMovement");
    }
}
