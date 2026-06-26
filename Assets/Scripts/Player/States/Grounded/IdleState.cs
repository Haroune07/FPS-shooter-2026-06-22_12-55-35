using UnityEngine;

public class IdleState : State<PlayerController>
{
    public IdleState(PlayerController ctx, StateFactory<PlayerController> stateFactory) : base(ctx, stateFactory)
    {
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        ctx.Mover.Decelerate(ctx.Stats.decelerationFactor, fixedDeltaTime);
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.Move != Vector2.zero)
            TransitionSelf(stateFactory.Get<MoveState>());

        if (ctx.Input.CrouchedThisFrame)
            TransitionSelf(stateFactory.Get<CrouchSuperState>());
    }
}