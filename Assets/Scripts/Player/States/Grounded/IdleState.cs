using UnityEngine;

public class IdleState : State<PlayerController>
{
    public IdleState(PlayerController ctx, StateFactory<PlayerController> stateFactory) : base(ctx, stateFactory)
    {
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.Move != Vector2.zero)
        {
            TransitionSelf(stateFactory.Get<WalkState>());
        }
    }
}