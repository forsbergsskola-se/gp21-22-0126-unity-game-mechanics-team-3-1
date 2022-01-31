using System;
using UnityEngine;

public class PlayerControllerHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float moveSpeed = 5f;
    public float jumpForce = 500f;

    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Get move input
        //Preferably get input in Update()
        var moveInput = Input.GetAxis("Horizontal");

        //Set move velocity
        //Preferably interact with physics in FixedUpdate() 
        myRigidbody.velocity = new Vector3(moveInput * moveSpeed, myRigidbody.velocity.y, 0);

        //Get jump input
        //Preferably get input in Update()
        var jumpInput = Input.GetKeyDown(KeyCode.Space);

        //Apply jump force
        //Preferably interact with physics in FixedUpdate() 
        if (jumpInput)
            myRigidbody.AddForce(Vector3.up * jumpForce);
    }
}