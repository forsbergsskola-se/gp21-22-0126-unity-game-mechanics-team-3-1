using UnityEngine;
using UnityEngine.XR;

public class PlayerWalkControllerHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainerHH commandContainer;
    private PlayerInputControllerHH playerInputController;
    private GroundCheckerHH groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float chargingMoveSpeedFactor = 0.5f;
    
    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        playerInputController = this.gameObject.GetComponent<PlayerInputControllerHH>();
        groundChecker = this.gameObject.GetComponent<GroundCheckerHH>();
        //playerInputController = this.GetComponentInChildren<PlayerInputControllerHH>();
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