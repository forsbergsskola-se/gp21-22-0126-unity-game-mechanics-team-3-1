using UnityEngine;

public class PlayerChargeJumpControllerHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private PlayerInputControllerHH playerInputController;
    private GroundCheckerHH groundChecker;
    [SerializeField] private float minimumJumpForce = 100f;
    [SerializeField] private float maximumJumpForce = 1000f;
    [SerializeField] private float chargeTime = 1f;

    private float jumpCharge;
    
    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        playerInputController = this.gameObject.GetComponent<PlayerInputControllerHH>();
        groundChecker = this.gameObject.GetComponent<GroundCheckerHH>();
    }

    private void Update()
    {
        HandleChargeJump();
    }

    private void HandleChargeJump()
    {
        if (playerInputController.JumpInput)
            jumpCharge += Time.deltaTime / chargeTime;

        if (playerInputController.JumpInputUp)
        {
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);
            jumpCharge = 0f;

            if (groundChecker.IsGrounded)
                myRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
