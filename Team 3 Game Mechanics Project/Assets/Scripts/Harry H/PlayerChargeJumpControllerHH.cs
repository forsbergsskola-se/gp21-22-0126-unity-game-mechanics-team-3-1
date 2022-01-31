using UnityEngine;

public class PlayerChargeJumpControllerHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainerHH commandContainer;
    private GroundCheckerHH groundChecker;
    [SerializeField] private float minimumJumpForce = 100f;
    [SerializeField] private float maximumJumpForce = 1000f;
    [SerializeField] private float chargeTime = 1f;

    private float jumpCharge;
    
    private void Awake()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        commandContainer = this.gameObject.GetComponentInChildren<CommandContainerHH>();
        groundChecker = this.gameObject.GetComponent<GroundCheckerHH>();
    }

    private void Update()
    {
        HandleChargeJump();
    }

    private void HandleChargeJump()
    {
        if (commandContainer.JumpCommand)
            jumpCharge += Time.deltaTime / chargeTime;

        if (commandContainer.JumpCommandDown)
        {
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);
            jumpCharge = 0f;

            if (groundChecker.IsGrounded)
                myRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}
