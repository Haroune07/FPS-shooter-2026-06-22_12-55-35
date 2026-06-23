using UnityEngine;

public class HSM<T>
{
    private T ctx;
    private State<T> rootState;


    public HSM(T ctx, State<T> startState)
    {
        this.ctx = ctx;
        rootState = startState;
        rootState?.EnterStates();
    }

    public void SwitchRootState(State<T> target)
    {
        rootState?.ExitStates();
        rootState = target;
        target.EnterStates();
    }

    public void Update(float deltaTime)
    {
        rootState?.CheckTransitionsCascade();
        rootState?.UpdateStates(deltaTime);   
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        rootState?.FixedUpdateStates(fixedDeltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        rootState?.OnTriggerEnterCascade(other);
    }

    public void OnTriggerExit(Collider other)
    {
        rootState?.OnTriggerExitCascade(other);
    }

    public void OnTriggerStay(Collider other)
    {
        rootState?.OnTriggerStayCascade(other);
    }
}