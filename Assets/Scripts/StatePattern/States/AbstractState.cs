
public abstract class AbstractState
{
    /// <summary>
    /// Defines a base template for the states.
    /// I use states only to trigger events and turn on or turn off certain behaviors.
    /// States themselves don't contain information and methods of the behaviors.
    /// </summary>
    /// <param name="manager">Takes a parameter of type StateManager</param>
    public abstract void EnterState(StateManager manager);
    public abstract void UpdateState(StateManager manager);
    public abstract void ExitState(StateManager manager);
}
