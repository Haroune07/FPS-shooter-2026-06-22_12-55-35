using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float walkSpeed = 7;
    public float sprintSpeed = 14;
    public float jumpForce = 5;
    public float crouchWalkSpeed = 4;
}
