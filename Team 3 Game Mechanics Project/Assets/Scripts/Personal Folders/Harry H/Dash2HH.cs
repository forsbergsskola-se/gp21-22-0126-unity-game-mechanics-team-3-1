using UnityEngine;

public class Dash2HH : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private const float dashVelocity = 45f;
    private float dashTime;
    [SerializeField] private const float startDashTime = 0.2f;
    private Vector3 dashDirection;
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
        if (dashDirection == Vector3.zero)
        {
            // use directional keycodes to assign a dash direction value + trigger velocity/effects methods
            if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                dashDirection = Vector3.left;
                ApplyVelocity(dashDirection);
                TriggerDashEffects();
            }
            else if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                dashDirection = Vector3.right;
                ApplyVelocity(dashDirection);
                TriggerDashEffects();
            }
            else if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                dashDirection = Vector3.up;
                ApplyVelocity(dashDirection);
                TriggerDashEffects();
            }
            else if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                dashDirection = Vector3.down;
                ApplyVelocity(dashDirection);
                TriggerDashEffects();
            }
        }
        else
        {
            // no longer dashing
            if (dashTime <= 0)
            {
                // resets
                dashDirection = Vector3.zero;
                rb.velocity = dashDirection;
                dashTime = startDashTime;
                trailRenderer.emitting = false;
            }
            else
            {
                // slowly decrease dashTime until it reaches 0 so dash stops
                dashTime -= Time.deltaTime;
            }
        }
    }

    // assigns velocity based on current dash direction until dashTime = 0
    private void ApplyVelocity(Vector3 dashDirection)
    {
        rb.velocity = dashDirection * dashVelocity;
    }

    private void TriggerDashEffects()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        trailRenderer.emitting = true;
    }
}
