using System;
using UnityEngine;

public class Dash2HH : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float dashVelocity = 45f;
    private float dashTime;
    private float startDashTime = 0.2f;
    private int dashDirection; 
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // check if already dashing
        if (dashDirection == 0)
        {
            // use directional keycodes to assign a dash direction value
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                dashDirection = 1;
            }
            else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                dashDirection = 2;
            }
            else if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                dashDirection = 3;
            }
            else if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                dashDirection = 4;
            }
        }
        else
        {
            // no longer dashing
            if (dashTime <= 0)
            {
                // resets
                dashDirection = 0;
                dashTime = startDashTime;
                rigidbody.velocity = Vector3.zero;
            }
            else
            {
                // slowly decrease dashTime until it reaches 0 so dash stops
                dashTime -= Time.deltaTime;
                
                // switch expression: assigns velocity based on current dash direction until dashTime = 0
                rigidbody.velocity = dashDirection switch
                {
                    1 => Vector3.left * dashVelocity, //rigidbody.velocity = Vector3.left * dashVelocity;
                    2 => Vector3.right * dashVelocity,
                    3 => Vector3.up * dashVelocity,
                    4 => Vector3.down * dashVelocity,
                    _ => rigidbody.velocity
                };
            }

        }
    }
}
