using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float walkSpeed = 7;
    public float sprintSpeed = 14;
    public float jumpForce = 5;
    public float crouchWalkSpeed = 4;
    public float decelerationFactor = 15;
    public float groundRayCastDist = 1.2f;
}
