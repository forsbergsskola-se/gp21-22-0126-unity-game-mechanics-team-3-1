using System;
using UnityEngine;

public class PlayerImmediateJumpController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainer commandContainer;
    private GroundChecker groundChecker;
    [SerializeField] private float jumpForce = 500f;

    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        commandContainer = this.gameObject.GetComponentInChildren<CommandContainer>();
        groundChecker = this.gameObject.GetComponent<GroundChecker>();
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
