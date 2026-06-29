using Unity.Mathematics;
using UnityEngine;

public class StandardMover : IMover
{
    private Vector2 _move;
    private Vector3 _smoothVel = Vector3.zero;
    private Vector3 _refSmoothVel = Vector3.zero;
    private PlayerController _ctx;
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
            newVel = Vector3.MoveTowards(currentVel, Vector3.zero, _ctx.Stats.walkSpeed * fixedDeltaTime * decelerationFactor);
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
        if (Physics.Raycast(_ctx.transform.position, Vector3.down, out RaycastHit hit, _ctx.Stats.groundRayCastDist))
            surfaceNormal = hit.normal;
        Vector3 projectedVel = Vector3.ProjectOnPlane(_smoothVel, surfaceNormal);
        Vector3 withRbVel = new(projectedVel.x, _ctx.Rb.linearVelocity.y, projectedVel.z);
        _ctx.Rb.linearVelocity = withRbVel;
    }

    /// <summary>
    /// Horizontal movement logic applied in airborne state
    /// </summary>
    /// <param name="controlFactor">Value between 0 and 1 representing the control over the velocity change</param>
    public void AirBorneMove(float controlFactor)
    {
        _move = _ctx.Input.Move;
        if (_move == Vector2.zero) return;

        Vector3 horizontalMoveInfluence = _ctx.transform.right * _move.x + _ctx.transform.forward * _move.y;
        _ctx.Rb.AddForce(horizontalMoveInfluence.normalized * controlFactor * _ctx.Stats.walkSpeed, ForceMode.Force);
        Vector3 horizontalVel = new(_ctx.Rb.linearVelocity.x, 0, _ctx.Rb.linearVelocity.z);
        float magnitude = Mathf.Clamp(horizontalVel.magnitude, 0, _ctx.Stats.sprintSpeed);
        horizontalVel = horizontalVel.normalized * magnitude;
        _ctx.Rb.linearVelocity = new(horizontalVel.x, _ctx.Rb.linearVelocity.y, horizontalVel.z);
    }
}