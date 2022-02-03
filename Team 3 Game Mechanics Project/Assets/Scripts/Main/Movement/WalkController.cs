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


    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        commandContainer = this.GetComponentInChildren<CommandContainer>();
        groundChecker = this.gameObject.GetComponent<GroundChecker>();
    }

    private void Update()
    {
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