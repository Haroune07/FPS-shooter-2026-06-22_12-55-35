
public class AirborneState : State<PlayerController>
{
    private float _groundedCheckCancelTimer;
    private const float MaxGroundCheckCancelTime = .15f;
    public AirborneState(PlayerController ctx, StateFactory<PlayerController> factory) : base(ctx, factory)
    {
    }

    public override void Enter()
    {
        _groundedCheckCancelTimer = 0f;
        if(ctx.Input.JumpThisFrame)
            InitSubState(stateFactory.Get<JumpState>());
        else
            InitSubState(stateFactory.Get<FallingState>());
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        _groundedCheckCancelTimer += fixedDeltaTime;
        ctx.Mover.AirBorneMove(ctx.Stats.AerialMovementControlFactor);
    }

    public override void CheckTransitions()
    {
        bool timeBufferCompleted = _groundedCheckCancelTimer >= MaxGroundCheckCancelTime;
        if(ctx.Grounded() && timeBufferCompleted)
            ctx.Hsm.SwitchRootState(stateFactory.Get<GroundedState>());
    }
}