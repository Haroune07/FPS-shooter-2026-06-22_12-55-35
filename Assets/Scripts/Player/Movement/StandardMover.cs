using UnityEngine;

public class StandardMover : IMover
{
    private Vector2 _move;
    private Vector3 _smoothVel = Vector3.zero;
    private Vector3 _refSmoothVel = Vector3.zero;
    PlayerController _ctx;
    public StandardMover(PlayerController ctx)
    {
        _ctx = ctx;
    }

    public void Decelerate(float decelerationFactor, float fixedDeltaTime)
    {
        Vector3 currentVel = _ctx.Rb.linearVelocity;
        Vector3 newVel;
        if (_ctx.IsOnSlope())
        {
            newVel = Vector3.zero;
        }
        else
        {
            currentVel.y = 0;
            newVel =  Vector3.MoveTowards(currentVel, Vector3.zero, _ctx.Stats.walkSpeed * fixedDeltaTime * decelerationFactor);
            newVel.y = _ctx.Rb.linearVelocity.y;
        }

        _ctx.Rb.linearVelocity = newVel;
    }

    public void Move(float speed)
    {
        _move = _ctx.Input.Move;
        Vector3 desiredVel = (_ctx.transform.forward * _move.y + _ctx.transform.right * _move.x) * speed;
        _smoothVel = Vector3.SmoothDamp(_smoothVel, desiredVel, ref _refSmoothVel, .01f);
        Vector3 surfaceNormal = Vector3.up;

        if(Physics.Raycast(_ctx.transform.position, Vector3.down, out RaycastHit hit , _ctx.Stats.groundRayCastDist))
            surfaceNormal = hit.normal;
        
        Vector3 projectedVel = Vector3.ProjectOnPlane(_smoothVel, surfaceNormal);
        Vector3 withRbVel = new (projectedVel.x, _ctx.Rb.linearVelocity.y, projectedVel.z);
        _ctx.Rb.linearVelocity = withRbVel;
    }
    
}