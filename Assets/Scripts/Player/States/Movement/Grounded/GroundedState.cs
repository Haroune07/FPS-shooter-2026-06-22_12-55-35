using UnityEngine;

public class GroundedState : State<PlayerController>
{

    private const int ConstantDownWardForce = 5;
    public GroundedState(PlayerController ctx, StateFactory<PlayerController> stateFactory) : base(ctx, stateFactory)
    {
    }
    public override void Enter()
    {
        Debug.Log("Enter Grounded");
        InitSubState(stateFactory.Get<IdleState>());
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        // amplifiy gravity
        ctx.Rb.AddForce(Vector3.down * ConstantDownWardForce , ForceMode.Force);
    }

    public override void CheckTransitions()
    {
        if((ctx.Input.JumpThisFrame && ctx.Grounded()) || !ctx.Grounded())
        {
            ctx.Hsm.SwitchRootState(stateFactory.Get<AirborneState>());
        }
    }
}