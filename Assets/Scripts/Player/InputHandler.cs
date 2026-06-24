using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private MyInputActions actions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created\\

    void Awake()
    {
        actions = new();
    }

    void OnEnable()
    {
        actions.Enable();
    }

    void OnDisable()
    {
        actions.Disable();
    }

    public Vector2 Move => actions.Player.Move.ReadValue<Vector2>();
    public Vector2 Look => actions.Player.Look.ReadValue<Vector2>();
    public bool JumpThisFrame => actions.Player.Jump.WasPressedThisFrame();
    public bool Sprint => actions.Player.Sprint.IsPressed();
}
