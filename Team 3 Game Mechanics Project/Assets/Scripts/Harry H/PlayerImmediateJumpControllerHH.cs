using System;
using UnityEngine;

public class PlayerImmediateJumpControllerHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private PlayerInputControllerHH playerInputController;
    private GroundCheckerHH groundChecker;
    [SerializeField] private float jumpForce = 500f;

    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        playerInputController = this.gameObject.GetComponent<PlayerInputControllerHH>();
        groundChecker = this.gameObject.GetComponent<GroundCheckerHH>();
    }

    private void Update()
    {
        //Apply jump force
        //Preferably interact with physics in FixedUpdate() 
        if (playerInputController.JumpInputDown && groundChecker.IsGrounded)
            myRigidbody.AddForce(Vector3.up * jumpForce);
    }
}
