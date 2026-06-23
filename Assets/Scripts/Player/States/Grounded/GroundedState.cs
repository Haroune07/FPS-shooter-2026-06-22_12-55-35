public class GroundedState : State<PlayerController>
{
    public GroundedState(PlayerController ctx, StateFactory<PlayerController> stateFactory) : base(ctx, stateFactory)
    {
    }
    public override void Enter()
    {
        SetSubState(stateFactory.Get<IdleState>());
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.JumpThisFrame)
        {
            ctx.Hsm.SwitchRootState(stateFactory.Get<AirborneState>());
        }
    }
}