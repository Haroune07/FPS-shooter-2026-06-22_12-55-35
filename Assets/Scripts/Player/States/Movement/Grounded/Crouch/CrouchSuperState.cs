using UnityEngine;

public class CrouchSuperState : State<PlayerController>
{
    public CrouchSuperState(PlayerController ctx, StateFactory<PlayerController> factory) : base(ctx, factory)
    {
    }

    public override void Enter()
    {
        ctx.transform.localScale = ctx.Stats.crouchedScale;
        ctx.transform.position -= new Vector3(0,ctx.Stats.crouchedScale.y,0);

        SetSubState(stateFactory.Get<CrouchIdle>());
    }

    public override void Exit()
    {
        ctx.transform.localScale = ctx.Stats.standingScale;
        ctx.transform.position += new Vector3(0,ctx.Stats.crouchedScale.y,0);
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.CrouchedThisFrame && VerifyCeilingHeight())
            TransitionSelf(stateFactory.Get<IdleState>());
    }

    private bool VerifyCeilingHeight()
    {
        // check if the ceiling isnt too low so the player can get up
        return ! Physics.Raycast(ctx.transform.position, Vector3.up, ctx.Stats.ceilingHitRayCastLength);
    }
}