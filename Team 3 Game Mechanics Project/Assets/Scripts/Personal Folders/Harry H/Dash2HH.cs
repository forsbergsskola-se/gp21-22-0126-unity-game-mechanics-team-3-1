using System;
using UnityEngine;

public class Dash2HH : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float dashVelocity = 45f;
    private float dashTime;
    private float startDashTime = 0.2f;
    private int direction;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (direction == 0)
        {
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                direction = 1;
            }
            else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                direction = 2;
            }
            else if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                direction = 3;
            }
            else if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rigidbody.velocity = Vector3.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                
                // switch expression: case 1 = rigidbody.velocity = Vector3.left * dashVelocity;
                rigidbody.velocity = direction switch
                {
                    1 => Vector3.left * dashVelocity,
                    2 => Vector3.right * dashVelocity,
                    3 => Vector3.up * dashVelocity,
                    4 => Vector3.down * dashVelocity,
                    _ => rigidbody.velocity
                };
            }

        }
    }
}
