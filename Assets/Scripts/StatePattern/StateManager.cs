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
        //Jack's Code
        _currentState = IdlingState;
        _currentState.EnterState(this);
        EventManager.Instance.OnMovementPressed += SwitchToWalking;
        EventManager.Instance.OnStoppedMoving += SwitchToIdle;
        EventManager.Instance.OnHidingInputPressed += SwitchToHiding;
        EventManager.Instance.OnWrongArrowPressed += SwitchToIdle;
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

    /// <summary>
    /// Switches to WalkingState, this method is subscribed to OnMovementPressed event from EventManager!
    /// </summary>'
    private void SwitchToWalking()
    {
        //print("switch to walking");
        IdlingState.ExitState(this);
        if(GameManager.Instance.Hiding == false )
        {
            SwitchState(WalkingState);
        }
            
    }
    /// <summary>
    /// Switches to IdlingState, this method is subscribed to OnStoppedMoving event from EventManager!
    /// </summary>'
    private void SwitchToIdle()
    {
        //print("switch to idle");
        GameManager.Instance.Hiding = false;
        if (_currentState == HidingState)
        {
            HidingState.ExitState(this);
        }

        if (_currentState == WalkingState)
        {
            WalkingState.ExitState(this);
        }
        SwitchState(IdlingState);
    }

    private void SwitchToHiding()
    {
        if (_currentState == IdlingState)
        {
            IdlingState.ExitState(this);
        }

        if (_currentState == WalkingState)
        {
            WalkingState.ExitState(this);
        }


        GameManager.Instance.Hiding = !GameManager.Instance.Hiding;
        if(GameManager.Instance.Hiding == true)
        {
            SwitchState(HidingState);
        }
        else
        {
            HidingState.ExitState(this);
            SwitchState(IdlingState);
        }
            
    }
}
