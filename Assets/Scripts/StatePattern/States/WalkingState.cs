using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : AbstractState
{
    private WalkingBehavior _walkingBehavior;

    public override void EnterState(StateManager manager)
    {
        _walkingBehavior = manager.GetComponent<WalkingBehavior>();
        _walkingBehavior.enabled = true;
    }

    public override void ExitState(StateManager manager)
    {
        _walkingBehavior.enabled = false;
    }

    public override void UpdateState(StateManager manager)
    {
        
    }
}
