using System;
using UnityEngine;
using UnityEngine.XR;

public class PlayerInputControllerHH : MonoBehaviour
{
    private CommandContainerHH commandContainer;
    
    // currently these fields are not accessed from others scripts
    // but are left public to show an example of public getter with private setter
    
    public float WalkInput { get; private set; }
    public bool JumpInputDown { get; private set; }
    public bool JumpInputUp { get; private set; }
    public bool JumpInput { get; private set; }

    private void Awake()
    {
        commandContainer = this.gameObject.GetComponentInChildren<CommandContainerHH>();
    }

    private void Update()
    {
        HandleInput();
        SetCommands();
    }

    private void HandleInput()
    {
        WalkInput = Input.GetAxis("Horizontal");
        JumpInputDown = Input.GetKeyDown(KeyCode.Space);
        JumpInputUp = Input.GetKeyUp(KeyCode.Space);
        JumpInput = Input.GetKey(KeyCode.Space);
    }

    private void SetCommands()
    {
        commandContainer.walkCommand = WalkInput;
        commandContainer.JumpCommandDown = JumpInputDown;
        commandContainer.JumpCommandUp = JumpInputUp;
        commandContainer.JumpCommand = JumpInput;
    }
}
