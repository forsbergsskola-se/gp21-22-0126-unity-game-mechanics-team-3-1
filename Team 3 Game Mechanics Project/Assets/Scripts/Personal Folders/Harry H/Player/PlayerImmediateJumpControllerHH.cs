using System;
using UnityEngine;

public class PlayerImmediateJumpControllerHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainerHH commandContainer;
    private GroundCheckerHH groundChecker;
    [SerializeField] private float jumpForce = 500f;

    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        commandContainer = this.gameObject.GetComponentInChildren<CommandContainerHH>();
        groundChecker = this.gameObject.GetComponent<GroundCheckerHH>();
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        //Apply jump force
        //Preferably interact with physics in FixedUpdate() 
        if (commandContainer.JumpCommandUp && groundChecker.IsGrounded)
            myRigidbody.AddForce(Vector3.up * jumpForce);
    }
}
