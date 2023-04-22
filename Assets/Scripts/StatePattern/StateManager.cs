using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    /// <summary>
    /// State Manager that I use as a component for Player.
    /// Sets Idling State as the first state.
    /// </summary>

    private AbstractState _currentState;
    public IdlingState IdlingState { get; set; }
    public WalkingState WalkingState { get; set; }
    public HidingState HidingState { get; set; }

    private void Awake()
    {
        IdlingState = new IdlingState();
        WalkingState = new WalkingState();
        HidingState = new HidingState();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentState = IdlingState;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    /// <summary>
    /// Public method to switch states to other states even within the concrete states.
    /// </summary>
    /// <param name="newState">Takes a state as a parameter.</param>
    public void SwitchState(AbstractState newState)
    {
        _currentState = newState;
        newState.EnterState(this);
    }
}
