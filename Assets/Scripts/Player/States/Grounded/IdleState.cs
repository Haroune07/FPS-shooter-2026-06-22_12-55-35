using UnityEngine;

public class IdleState : State<PlayerController>
{
    private float decelerationFactor = 10;
    public IdleState(PlayerController ctx, StateFactory<PlayerController> stateFactory) : base(ctx, stateFactory)
    {
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        Vector3 currentVel = ctx.Rb.linearVelocity;
        currentVel.y = 0;
        Vector3 newVel =  Vector3.MoveTowards(currentVel, Vector3.zero, ctx.Stats.walkSpeed * fixedDeltaTime * decelerationFactor);
        newVel.y = ctx.Rb.linearVelocity.y;
        ctx.Rb.linearVelocity = newVel;
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.Move != Vector2.zero)
            TransitionSelf(stateFactory.Get<MoveState>());

        if (ctx.Input.CrouchedThisFrame)
            TransitionSelf(stateFactory.Get<CrouchSuperState>());
    }

    public override void Exit()
    {
        Debug.Log("exit idle");
    }
}