using UnityEngine;
using UnityEngine.XR;

public class PlayerWalkController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainer commandContainer;
    private GroundChecker groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float chargingMoveSpeedFactor = 0.5f;
    
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
        var currentMoveSpeed = moveSpeed;
        if (commandContainer.JumpCommand && groundChecker.IsGrounded)
            currentMoveSpeed *= chargingMoveSpeedFactor;

        myRigidbody.velocity = new Vector3(commandContainer.walkCommand * currentMoveSpeed, myRigidbody.velocity.y, 0);
    }
}