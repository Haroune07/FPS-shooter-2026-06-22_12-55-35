using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float walkSpeed = 9;
    public float sprintSpeed = 15;
    public float jumpForce = 5;
}
