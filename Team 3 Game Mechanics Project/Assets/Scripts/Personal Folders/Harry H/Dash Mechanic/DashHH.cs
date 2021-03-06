using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DashHH : MonoBehaviour
{
    
    // used components
    private Rigidbody Rb;
    private GroundChecker groundChecker;
    private TrailRenderer trailRenderer;
    private Animator animator;
    private Transform playerTransform;
    private CameraShakeHH cameraShake;
    
    // dashing variables
    [SerializeField] private DashSpeedSO dashSpeedSo;
    [SerializeField] private float dashingTime;

    private Vector3 dashingDirection;
    public bool isDashing { get; private set; } = false;
    public bool canDash;
    private bool NoWait = true;

    private Image energyBar;
    private GameObject energyText;
    private int energyFillAmount;
    
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
        cameraShake = GetComponentInChildren<CameraShakeHH>();
        playerTransform = FindObjectOfType<PlayerIdentifier>().gameObject.transform;
        canDash = true;

        // Assign Player Specific components and their start values
        if (!GetComponent<PlayerIdentifier>()) return;
        energyBar = GameObject.Find("Energy Fill").GetComponent<Image>();
        energyText = GameObject.Find("Energy Text");
        energyBar.fillAmount = 1;
        energyText.SetActive(true);
    }

    // dash logic
    private void Update()
    {
        // dash energy UI logic
        if (GetComponent<PlayerIdentifier>())
        {
            energyBar.fillAmount = canDash == false ? 0 : 1;
            energyText.SetActive(canDash != false);
        }
        
        // assign unique input from input manager
        var dashInput = Input.GetButtonDown("Dash");

        // TODO: add stamina check or another reset factor to nerf this
        // only dash when able to
        if (canDash)
        {
            // Player can only dash when input is given
            if (GetComponent<PlayerIdentifier>() && !dashInput)
            {
                return;
            }
            
            // can't dash when dashing
            isDashing = true;
            canDash = false;
            
            // trail renderer triggers when dashing
            trailRenderer.emitting = true;

            // toggles dash direction for Player using input axis data
            if (GetComponent<PlayerIdentifier>())
            {
                StartCoroutine(cameraShake.Shake(.15f, .4f));

                dashingDirection = flyingDashUnlocked switch
                {
                    // use raw horizontal to determine direction of dash (can move left or right)
                    false => new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0),

                    // use raw horizontal and vertical inputs to determine direction of dash (can go diagonal and up)
                    true => new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0)
                };
            }
            // enemies use direction to Player for dash direction
            else
            {
                var proximityToPlayer = Mathf.Abs(playerTransform.position.x - transform.position.x);
                if (proximityToPlayer < 10)
                {
                    // Dasher AI logic: uses dash to pursue player
                    if (GetComponent<DasherAIIdentifier>()) 
                        dashingDirection = new Vector3(playerTransform.position.x - transform.position.x, 0, 0);
                
                    // Sky Dasher AI Logic: uses dash to go into the air above the Player
                    else if ((proximityToPlayer < 5) && GetComponent<SkyDasherAIIdentifier>())
                        dashingDirection = new Vector3(0, transform.position.y + 8, 0);

                    // Evader Ai Logic: uses dash to get away from player when too close
                    else if ((proximityToPlayer < 2) && (GetComponent<EvaderAIIdentifier>()))
                        dashingDirection = new Vector3(playerTransform.position.x + transform.position.x, 0, 0);
                }
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
        
        // can only dash once grounded again and after cooldown has ended
        if (canDash == false && groundChecker.IsGrounded && NoWait)
        {
            StartCoroutine(DashCooldown());
        }
    }

    // stop dashing and trail effects after set time
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        isDashing = false;
    }

    // unable to dash until cooldown time is reached
    private IEnumerator DashCooldown()
    {
        NoWait = false;
        yield return new WaitForSeconds(dashSpeedSo.DashCoolDownTime);
        canDash = true;
        NoWait = true;
        Debug.Log("Can Dash again");
    }
}
