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

    public void SetSubState(State<T> target)
    {
        subState?.ExitStates();
        subState = target;
        target.parentState = this;
        target.EnterStates();
    }

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
    
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        
    }

    public virtual void OnTriggerExit(Collider other)
    {
        
    }

    public virtual void OnTriggerStay(Collider other)
    {
        
    }

    public virtual void Update(float deltaTime)
    {
        
    }

    public virtual void FixedUpdate(float fixedDeltaTime)
    {
        
    }

    public void EnterStates()
    {
        Enter();
        subState?.EnterStates();
    }
    
    public void ExitStates()
    {
        subState?.ExitStates();
        Exit();
    }

    public void UpdateStates(float deltaTime)
    {
        Update(deltaTime);
        subState?.UpdateStates(deltaTime);
    }

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

    public void CheckTransitionsCascade()
    {
        CheckTransitions();
        subState?.CheckTransitionsCascade();
    }

    public virtual void CheckTransitions()
    {
        
    }
}