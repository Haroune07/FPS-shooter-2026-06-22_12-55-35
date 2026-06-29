using UnityEngine;

public abstract class State<T>
{
    protected T ctx;

    public State<T> subState;
    public State<T> parentState;
    protected StateFactory<T> stateFactory;

    public State(T ctx, StateFactory<T> factory)
    {
        this.ctx = ctx;
        stateFactory = factory;
    }

    /// <summary>
    /// Sets current childState with cascade exiting but no cascade entering - only the argument state calls the enter state. 
    /// this method is meant to be used in State.Enter() to decide what is going to be the substate.
    /// </summary>
    /// <param name="target">new sub state to be set </param>
    public void InitSubState(State<T> target)
    {
        subState?.ExitStates();
        subState = target;
        subState.parentState = this;
    }

    /// <summary>
    /// Sets current child state with cascade exiting the previous state and cascade entering the new target state
    /// </summary>
    /// <param name="target">new sub state to be set</param>
    public void SetSubState(State<T> target)
    {
        subState?.ExitStates();
        subState = target;
        target.parentState = this;
        target.EnterStates();
    }

    /// <summary>
    /// Transition from one state to another brother state in the state hierarchy
    /// </summary>
    /// <param name="target">brother state to trantition to</param>
    /// <exception cref="System.Exception">Exception thrown when a root state uses this method - (a root state doesnt have any parent so it doesnt have brothers)</exception>
    public void TransitionSelf(State<T> target)
    {
        ExitStates();

        if (parentState == null)
        {
            throw new System.Exception($"Root state {GetType()} cannot use this function");
        }

        target.parentState = parentState;
        parentState.subState = target;
        target.EnterStates();
    }

    /// <summary>
    /// executed once per state enter
    /// </summary>
    public virtual void Enter()
    {

    }

    /// <summary>
    /// executed once per state exit
    /// </summary>
    public virtual void Exit()
    {

    }

    /// <param name="other">Collider of the other object</param>
    public virtual void OnTriggerEnter(Collider other)
    {

    }

    /// <param name="other">Collider of the other object</param>
    public virtual void OnTriggerExit(Collider other)
    {

    }

    /// <param name="other">Collider of the other object</param>
    public virtual void OnTriggerStay(Collider other)
    {

    }

    /// <summary>
    ///     state logic executed each frame
    /// </summary>
    /// <param name="deltaTime">time since last update call</param>
    public virtual void Update(float deltaTime)
    {

    }

    /// <summary>
    /// state logic executed each fixed time interval (see unity for exact numbers)
    /// </summary>
    /// <param name="fixedDeltaTime">time since last FixedUpdate call</param>
    public virtual void FixedUpdate(float fixedDeltaTime)
    {

    }


    /// <summary>
    /// enter states from parent to children
    /// </summary>
    public void EnterStates()
    {
        Enter();
        subState?.EnterStates();
    }

    /// <summary>
    /// exit states from children to parent
    /// </summary>
    public void ExitStates()
    {
        subState?.ExitStates();
        Exit();
    }

    /// <summary>
    /// updating states from parent to children
    /// </summary>
    /// <param name="deltaTime">time since last update call</param>
    public void UpdateStates(float deltaTime)
    {
        Update(deltaTime);
        subState?.UpdateStates(deltaTime);
    }

    /// <summary>
    /// fixed update state from parent to children
    /// </summary>
    /// <param name="fixedDeltaTime"></param>
    public void FixedUpdateStates(float fixedDeltaTime)
    {
        FixedUpdate(fixedDeltaTime);
        subState?.FixedUpdateStates(fixedDeltaTime);
    }

    public void OnTriggerEnterCascade(Collider other)
    {
        OnTriggerEnter(other);
        subState?.OnTriggerEnterCascade(other);
    }

    public void OnTriggerExitCascade(Collider other)
    {
        OnTriggerExit(other);
        subState?.OnTriggerExitCascade(other);
    }

    public void OnTriggerStayCascade(Collider other)
    {
        OnTriggerStay(other);
        subState?.OnTriggerStayCascade(other);
    }

    /// <summary>
    /// verifiying state transitions from parent to children
    /// </summary>
    public void CheckTransitionsCascade()
    {
        CheckTransitions();
        subState?.CheckTransitionsCascade();
    }

    /// <summary>
    /// method to call each frame to conditionally transition states. Runs in parallel with the Update() method
    /// </summary>
    public virtual void CheckTransitions()
    {
        
    }
}