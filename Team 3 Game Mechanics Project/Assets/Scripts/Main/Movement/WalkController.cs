using UnityEngine;
using UnityEngine.XR;

public class WalkController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainer commandContainer;
    private GroundChecker groundChecker;
    // [SerializeField] private float walkSpeed = 5f;
    // [SerializeField] private float chargingWalkSpeedFactor = 0.5f;
    [SerializeField] private WalkSpeedSO walkSpeedSO;

    private DashHH dash;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        commandContainer = GetComponentInChildren<CommandContainer>();
        groundChecker = GetComponent<GroundChecker>();
        dash = GetComponent<DashHH>();
    }

    private void Update()
    {
        // Harry: Logic only applies if this Entity has a Dash component
        if (GetComponent<DashHH>())
        {
            // Harry: Can only walk if not dashing
            if (dash.isDashing)
            {
                return;
            }
        }
        HandleWalking();
    }

    private void HandleWalking()
    {
        //Slower move speed while charging a jump.
        var currentMoveSpeed = walkSpeedSO.WalkSpeed;
        if (commandContainer.JumpCommand && groundChecker.IsGrounded)
            currentMoveSpeed *= walkSpeedSO.ChargingWalkSpeedFactor;

        myRigidbody.velocity = new Vector3(commandContainer.walkCommand * currentMoveSpeed, myRigidbody.velocity.y, 0);
    }
}