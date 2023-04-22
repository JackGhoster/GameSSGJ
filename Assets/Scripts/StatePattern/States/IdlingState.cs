using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : AbstractState
{
    public override void EnterState(StateManager manager)
    {
        Debug.Log("Entering Idling State");
    }

    public override void ExitState(StateManager manager)
    {
        Debug.Log("Exiting Idling State");
    }

    public override void UpdateState(StateManager manager)
    {
        Debug.Log("Updating Idling State");
    }

}
