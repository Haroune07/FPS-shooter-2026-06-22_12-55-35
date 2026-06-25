using UnityEngine;
public class CrouchWalk : State<PlayerController>
{
    public CrouchWalk(PlayerController ctx, StateFactory<PlayerController> factory) : base(ctx, factory)
    {
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        ctx.Mover.Move(ctx.Stats.crouchWalkSpeed);
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.Move == Vector2.zero)
            TransitionSelf(stateFactory.Get<CrouchIdle>());
    }
}