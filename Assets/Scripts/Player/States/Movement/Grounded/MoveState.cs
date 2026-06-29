using UnityEngine;

public class MoveState : State<PlayerController>
{
    public MoveState(PlayerController ctx, StateFactory<PlayerController> stateFactory) : base(ctx, stateFactory)
    {
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        ctx.Mover.Move(ctx.Stats.walkSpeed);
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.Move == Vector2.zero)
            TransitionSelf(stateFactory.Get<IdleState>());

        if(ctx.Input.Sprint)
            TransitionSelf(stateFactory.Get<SprintState>());
        
        if (ctx.Input.CrouchedThisFrame)
            TransitionSelf(stateFactory.Get<CrouchSuperState>());
    }
}