using UnityEngine;

public class WalkState : State<PlayerController>
{
    private Rigidbody rb;
    private Transform transform;  
    private Vector2 move;
    Vector3 smoothVel = Vector3.zero;
    Vector3 refSmoothVel = Vector3.zero;

    private float walkSpeed;

    public WalkState(PlayerController ctx, StateFactory<PlayerController> stateFactory) : base(ctx, stateFactory)
    {
        rb = ctx.Rb;
        transform = ctx.transform;
        float walkSpeed = ctx.Stats.walkSpeed;
    }

    public override void FixedUpdate(float fixedDeltaTime)
    {
        move = ctx.Input.Move;

        Vector3 desiredVel = (transform.forward * move.y + transform.right * move.x) * walkSpeed;
    
        smoothVel = Vector3.SmoothDamp(smoothVel, desiredVel, ref refSmoothVel, .01f);

        Vector3 surfaceNormal = Vector3.up;

        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit , 2))
        {
            surfaceNormal = hit.normal;
        }

        Vector3 projectedVel = Vector3.ProjectOnPlane(smoothVel, surfaceNormal);

        Vector3 withRbVel = new (projectedVel.x, rb.linearVelocity.y, projectedVel.z);

        rb.linearVelocity = withRbVel;
    }

    public override void CheckTransitions()
    {
        if(ctx.Input.Move == Vector2.zero)
        {
            TransitionSelf(stateFactory.Get<IdleState>());
        }
    }
}