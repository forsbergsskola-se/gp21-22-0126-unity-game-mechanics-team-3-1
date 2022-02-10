using System.Collections;
using UnityEngine;

public class Dash2HH : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float dashForce = 2500f;
    private float dashTime;
    [SerializeField] private float startDashTime = 0.2f;
    private Vector3 dashDirection;
    private CameraShakeHH cameraShake;
    private TrailRenderer trailRenderer;
    //private bool canDash;
    [SerializeField] private float dashCooldownTime = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraShake = GetComponentInChildren<CameraShakeHH>();
        trailRenderer = GetComponent<TrailRenderer>();
        //canDash = true;
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
                
                //StartCoroutine(DashCooldown());
            }
        }
    }

    // assigns force added based on current dash direction until dashTime = 0
    private void ApplyVelocity(Vector3 dashDirection)
    {
        rb.AddForce(dashDirection * dashForce);
    }

    private void TriggerDashEffects()
    {
        StartCoroutine(cameraShake.Shake(.05f, .1f));
        trailRenderer.emitting = true;
    }

    // Had planned a cooldown but it wasn't working as desired
    // TODO: Implement this
    private IEnumerator DashCooldown()
    {
        //canDash = false;
        yield return new WaitForSeconds(dashCooldownTime);
        Debug.Log("Dash two active");
        //canDash = true;
        yield return null;
    }
}
