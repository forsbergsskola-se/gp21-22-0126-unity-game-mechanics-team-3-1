using System;
using System.Collections;
using UnityEngine;

public class DashHH : MonoBehaviour
{
    
    // used components
    private Rigidbody Rb;
    private GroundChecker groundChecker;
    private TrailRenderer trailRenderer;
    private Animator animator;
    
    // dashing variables
    [SerializeField] private float dashingVelocity;
    [SerializeField] private float dashingTime;
    private Vector3 dashingDirection;
    private bool isDashing;
    private bool canDash = true;


    // assign components
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        groundChecker = GetComponent<GroundChecker>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // dash logic
    private void Update()
    {
        // assign unique input from input manager
        var dashInput = Input.GetButtonDown("Dash");

        // only dash when input is correct and is able to dash
        if (dashInput && canDash)
        {
            // can't dash when dashing
            isDashing = true;
            canDash = false;
            
            // trail renderer triggers when dashing
            trailRenderer.emitting = true;

            // use raw horizontal and vertical inputs to determine direction of dash
            dashingDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            
            // if no direction input use localScale X value to determine direction of dash
            if (dashingDirection == Vector3.zero)
            {
                dashingDirection = new Vector3(transform.localScale.x, 0, 0);
            }

            // trigger coroutine
            StartCoroutine(StopDashing());

        }
        
        // TODO: add animation logic
        //animator.SetBool("isDashing", isDashing);
        //animator.SetBool("cameraShake", isDashing);
        
        
        // dashing logic: set rigidbody velocity to normalised dash direction * modified velocity
        if (isDashing)
        {
            Rb.velocity = dashingDirection.normalized * dashingVelocity;
            // return so not interrupted
            return;
        }
        
        // only dash when grounded
        // TODO: add stamina or another reset factor to nerf this
        
        if (groundChecker.IsGrounded)
        {
            canDash = true;
        }
    }

    // stop dashing and trail effects after set time
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
    }
}
