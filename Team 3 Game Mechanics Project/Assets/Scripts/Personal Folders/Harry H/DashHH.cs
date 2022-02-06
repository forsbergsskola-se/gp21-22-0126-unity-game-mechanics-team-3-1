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
    [SerializeField] private DashSpeedSO dashSpeedSo;
    [SerializeField] private float dashingTime;
    private Vector3 dashingDirection;
    public bool isDashing { get; private set; } = false;
    private bool canDash = true;
    
    /// <summary>
    /// Bool activated by UpgradeUnlockedHH.cs once triggered.
    /// When true it unlocks an upgraded version of the dash.
    /// </summary>
    [HideInInspector] public bool flyingDashUnlocked = false;


    // assign components
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        groundChecker = GetComponent<GroundChecker>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.emitting = false;
    }

    // dash logic
    private void Update()
    {
        // assign unique input from input manager
        var dashInput = Input.GetButtonDown("Dash");

        // TODO: add stamina check or another reset factor to nerf this
        // only dash when input is correct and is able to dash
        if (dashInput && canDash)
        {
            // can't dash when dashing
            isDashing = true;
            canDash = false;
            
            // trail renderer triggers when dashing
            trailRenderer.emitting = true;
            
            // toggles dash direction
            dashingDirection = flyingDashUnlocked switch
            {
                // use raw horizontal to determine direction of dash (can move left or right)
                false => new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0),
                
                // use raw horizontal and vertical inputs to determine direction of dash (can go diagonal and up)
                true => new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0)
            };

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
            // Uses scriptable object to vary dash speed between AI types & Player
            Rb.velocity = dashingDirection.normalized * dashSpeedSo.DashVelocity;
            // return so not interrupted
            return;
        }
        
        // reset canDash
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
