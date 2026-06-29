using UnityEngine;

public class JumpState : State<PlayerController>
{
    public JumpState(PlayerController ctx, StateFactory<PlayerController> factory) : base(ctx, factory)
    {
    }

    public override void Enter()
    {
        // apply instant jumping force
        ctx.Rb.AddForce(Vector3.up * ctx.Stats.jumpForce, ForceMode.Impulse);
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        if(ctx.Rb.linearVelocity.y < ctx.Stats.yVelFallThreshold)
        {
            TransitionSelf(stateFactory.Get<FallingState>());
        }
    }
}