using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingState : AbstractState
{
    private HidingBehavior _hidingBehavior;
    public override void EnterState(StateManager manager)
    {
        _hidingBehavior = manager.GetComponent<HidingBehavior>();
        _hidingBehavior.enabled = true;
    }

    public override void ExitState(StateManager manager)
    {
        _hidingBehavior.enabled = false;
    }

    public override void UpdateState(StateManager manager)
    {

    }
}
