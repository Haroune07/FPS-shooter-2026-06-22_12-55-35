using UnityEngine;
public class SprintState : State<PlayerController>
{

    public SprintState(PlayerController ctx, StateFactory<PlayerController> factory) : base(ctx, factory)
    {
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        ctx.Mover.Move(ctx.Stats.sprintSpeed);
    }

    public override void CheckTransitions()
    {
        if (!ctx.Input.Sprint)
            TransitionSelf(stateFactory.Get<MoveState>());
    }
}