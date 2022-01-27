using System;
using UnityEngine;

public class PlayerControllerHH : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 5f;
    private Rigidbody myRigidBody;
    private enum KeyState { Off, Down, Held, Up } 
    private KeyState ksHorizontal = KeyState.Off;
    private KeyState ksSpace = KeyState.Off;

    private void Awake()
    {
        myRigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Move left and right Inputs
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            ksHorizontal = KeyState.Down;
        } 
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            ksHorizontal = KeyState.Up;
        }
        
        // Jumping inputs

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ksSpace = KeyState.Down;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ksSpace = KeyState.Up;
        }
    }

    private void FixedUpdate()
    {
        // Moving logic
        
        switch (ksHorizontal)
        {
            case KeyState.Down:
            {
                // "Move" key pressed
                // set move Input & Interact with Physics
                ksHorizontal = KeyState.Held;
                break;
            }
            case KeyState.Held:
                // Holding "Move" 
                myRigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, myRigidBody.velocity.y, 0);
                break;
            case KeyState.Off:
                break;
            case KeyState.Up:
                // "Move" released
                ksHorizontal = KeyState.Off;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        // Jumping logic
        
        switch (ksSpace)
        {
            case KeyState.Down:
            {
                ksSpace = KeyState.Held;
                break;
            }
            case KeyState.Held:
                // Holding "Jump"
                if (myRigidBody.velocity.y == 0)
                {
                    Debug.Log("Jump");
                    myRigidBody.AddForce(Vector3.up * jumpForce * 100);
                }
                break;
            case KeyState.Off:
                break;
            case KeyState.Up:
                // "Jump" released
                ksSpace = KeyState.Off;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
