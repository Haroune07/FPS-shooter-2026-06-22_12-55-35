using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float walkSpeed = 6;
    public float sprintSpeed = 12;
    public float jumpForce = 5;
    public float crouchWalkSpeed = 4;
    public float decelerationFactor = 15;
    public float groundRayCastDist = 1.3f;

    public float AirborneMoveSpeed;

    public Vector3 standingScale = Vector3.one;
    public readonly Vector3 crouchedScale;
    public float ceilingHitRayCastLength = .6f;
    public float yVelFallThreshold = -1;

    public float AerialMovementControlFactor = .3f;
    public PlayerStats()
    {
        crouchedScale = new Vector3(standingScale.x, standingScale.y / 2, standingScale.z);
    }
}
