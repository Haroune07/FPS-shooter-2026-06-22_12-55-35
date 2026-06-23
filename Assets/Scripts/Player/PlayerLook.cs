using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensibility = 20, xClampAngle = 40;
    private float rotX, rotY;
    private Vector2 look;
    private InputHandler input;
    public Camera cam;

    public float rotateSmoothFactor = 40f;

    void Start()
    {
        input = GetComponent<InputHandler>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        look = input.Look;

        rotX -= look.y * Time.deltaTime * sensibility;
        rotY += look.x * Time.deltaTime * sensibility;

        rotX = Mathf.Clamp(rotX, -xClampAngle, xClampAngle);

        Quaternion playerTurnRotation = Quaternion.Euler(0, rotY, 0);
        Quaternion camRotation = Quaternion.Euler(rotX, 0, 0);
        
        cam.transform.localRotation = camRotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, playerTurnRotation, rotateSmoothFactor * Time.deltaTime);

    }
}
