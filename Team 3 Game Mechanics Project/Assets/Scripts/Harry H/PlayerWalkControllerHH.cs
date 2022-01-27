using UnityEngine;

public class PlayerWalkControllerHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private PlayerInputControllerHH playerInputController;
    private GroundCheckerHH groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float chargingMoveSpeedFactor = 0.5f;
    
    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        playerInputController = this.gameObject.GetComponent<PlayerInputControllerHH>();
        groundChecker = this.gameObject.GetComponent<GroundCheckerHH>();
    }

    private void Update()
    {
        //Slower move speed while charging a jump.
        var currentMoveSpeed = moveSpeed;
        if (playerInputController.JumpInput && groundChecker.IsGrounded)
            currentMoveSpeed *= chargingMoveSpeedFactor;

        myRigidbody.velocity = new Vector3(playerInputController.MoveInput * currentMoveSpeed, myRigidbody.velocity.y, 0);
    }
}