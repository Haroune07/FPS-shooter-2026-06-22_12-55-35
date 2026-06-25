using UnityEngine;

/// <summary>
/// centralize input in player HSM for consistent values instead of having each class query input handler 
/// </summary>
public struct InputData
{
    public Vector2 Move;
    public Vector2 Look;
    public bool JumpThisFrame;
    public bool Sprint;
    public bool CrouchedThisFrame;
    public bool HoldCrouch;

    public InputData(Vector2 move, Vector2 look, bool jumpThisFrame, bool sprint, bool crouchedThisFrame, bool holdCrouch)
    {
        Move = move;
        Look = look;
        JumpThisFrame = jumpThisFrame;
        Sprint = sprint;
        CrouchedThisFrame = crouchedThisFrame;
        HoldCrouch = holdCrouch;
    }
}