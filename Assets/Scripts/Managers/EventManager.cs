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
        print("hide");
        if ( OnHidingInputPressed != null )
        {
            OnHidingInputPressed();
        }
    }
}
