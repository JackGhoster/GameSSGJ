using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : AbstractState
{
    private IdlingBehavior _idlingBehavior;

    public override void EnterState(StateManager manager)
    {
        _idlingBehavior = manager.GetComponent<IdlingBehavior>();
        _idlingBehavior.enabled = true;
    }

    public override void ExitState(StateManager manager)
    {
        //Debug.Log("Exiting Idling State");
        _idlingBehavior.enabled = false;
    }

    public override void UpdateState(StateManager manager)
    {
        
    }

}
