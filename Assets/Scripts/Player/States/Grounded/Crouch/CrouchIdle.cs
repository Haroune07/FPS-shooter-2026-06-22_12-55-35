using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CrouchIdle : State<PlayerController>
{
    public CrouchIdle(PlayerController ctx, StateFactory<PlayerController> factory) : base(ctx, factory)
    {
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        ctx.Mover.Decelerate(ctx.Stats.decelerationFactor, fixedDeltaTime);
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.Move != Vector2.zero)
            TransitionSelf(stateFactory.Get<CrouchWalk>());
    }
}