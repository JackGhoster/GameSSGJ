using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action OnIdling;
    public event Action OnWalking;
    public event Action OnHidingInputPressed;
    public event Action OnMovementPressed;
    public event Action OnStoppedMoving;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void Idling()
    {
        if(OnIdling != null)
        {
            OnIdling();
        }
    }
    public void Walking()
    {
        if(OnWalking != null)
        {
            OnWalking();
        }
    }
    public void HideInputPressed()
    {
        if ( OnHidingInputPressed != null )
        {
            OnHidingInputPressed();
        }
    }

    public void MovementPressed()
    {
        if( OnMovementPressed != null)
        {
            OnMovementPressed();
        }
    }
    public void StoppedMoving()
    {
        if(OnStoppedMoving != null)
        {
            OnStoppedMoving();
        }
    }
}
