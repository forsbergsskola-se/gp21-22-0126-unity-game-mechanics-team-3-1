using UnityEngine;

public class Dash2HH : MonoBehaviour
{
    private Rigidbody rb;
    private float dashVelocity = 45f;
    private float dashTime;
    private float startDashTime = 0.2f;
    private int dashDirection; // change to Vector3
    private CameraShakeHH cameraShake;
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraShake = GetComponent<CameraShakeHH>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        // check if already dashing
        if (dashDirection == 0) // change to Vector3.zero
        {
            // use directional keycodes to assign a dash direction value
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                dashDirection = 1;
                TriggerDashEffects();
            }
            else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                dashDirection = 2;
                TriggerDashEffects();
            }
            else if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                dashDirection = 3;
                TriggerDashEffects();
            }
            else if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                dashDirection = 4;
                TriggerDashEffects();
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
                rb.velocity = Vector3.zero;
                trailRenderer.emitting = false;
            }
            else
            {
                // slowly decrease dashTime until it reaches 0 so dash stops
                dashTime -= Time.deltaTime;

                // switch expression: assigns velocity based on current dash direction until dashTime = 0
                rb.velocity = dashDirection switch
                {
                    1 => Vector3.left * dashVelocity, //rigidbody.velocity = Vector3.left * dashVelocity;
                    2 => Vector3.right * dashVelocity,
                    3 => Vector3.up * dashVelocity,
                    4 => Vector3.down * dashVelocity,
                    _ => rb.velocity
                };
            }
        }
    }

    private void TriggerDashEffects()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        trailRenderer.emitting = true;
    }
}
