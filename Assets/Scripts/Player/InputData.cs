using UnityEngine;

/// <summary>
/// centralize input for consistent values instead of having each class query input handler 
/// </summary>
public struct InputData
{
    public Vector2 Move {get; private set;}
    public Vector2 Look {get; private set;}
    public bool JumpThisFrame {get; private set;}
    public bool Sprint {get; private set;}
    public bool CrouchedThisFrame {get; private set;}
    public bool HoldCrouch {get; private set;} // use this for slide later on
    public bool FirePressed {get; private set;}
    public bool AimHeld {get; private set;}
    public bool ReloadThisFrame {get; private set;}

    public InputData(InputHandler inputHandler)
    {
        Move = inputHandler.Move;
        Look = inputHandler.Look;
        JumpThisFrame = inputHandler.JumpThisFrame;
        Sprint = inputHandler.Sprint;
        CrouchedThisFrame = inputHandler.CrouchThisFrame;
        HoldCrouch = inputHandler.HoldCrouch;
        FirePressed = inputHandler.FirePressed;
        AimHeld = inputHandler.AimHeld;
        ReloadThisFrame = inputHandler.ReloadThisFrame;
    }
}