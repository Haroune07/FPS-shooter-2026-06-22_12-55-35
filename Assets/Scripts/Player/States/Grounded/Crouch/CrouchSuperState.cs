using UnityEngine;

public class CrouchSuperState : State<PlayerController>
{
    public CrouchSuperState(PlayerController ctx, StateFactory<PlayerController> factory) : base(ctx, factory)
    {
    }

    public override void Enter()
    {
        Debug.Log("Crouch entered");
        // reduce height
    }

    public override void Exit()
    {
        Debug.Log("Crouch exited");
        ///bring back height to normal
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.CrouchedThisFrame && CheckCeilingHit())
            TransitionSelf(stateFactory.Get<IdleState>());
    }

    private bool CheckCeilingHit()
    {
        // check if the ceiling isnt too low so the player can get up
        return true;
    }
}