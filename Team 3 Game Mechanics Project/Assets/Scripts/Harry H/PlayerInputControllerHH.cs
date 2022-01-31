using UnityEngine;
using UnityEngine.XR;

public class PlayerInputControllerHH : MonoBehaviour
{
    public float MoveInput { get; private set; }
    public bool JumpInputDown { get; private set; }
    public bool JumpInputUp { get; private set; }
    public bool JumpInput { get; private set; }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        MoveInput = Input.GetAxis("Horizontal");
        JumpInputDown = Input.GetKeyDown(KeyCode.Space);
        JumpInputUp = Input.GetKeyUp(KeyCode.Space);
        JumpInput = Input.GetKey(KeyCode.Space);
    }
}
