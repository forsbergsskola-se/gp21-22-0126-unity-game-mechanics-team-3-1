using UnityEngine;
using UnityEngine.Events;

public class ChargeJumpController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainer commandContainer;
    private GroundChecker groundChecker;
    [SerializeField] private float minimumJumpForce = 100f;
    [SerializeField] private float maximumJumpForce = 1000f;
    [SerializeField] private float chargeTime = 1f;
    [SerializeField] private UnityEvent<float> onChargeJump;

    private float jumpCharge;
    
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        commandContainer = GetComponentInChildren<CommandContainer>();
        groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        HandleChargeJump();
    }

    private void HandleChargeJump()
    {
        if (commandContainer.JumpCommand)
        {
            jumpCharge += Time.deltaTime / chargeTime;
            jumpCharge = Mathf.Clamp01(jumpCharge); // clamps jumpCharge between a 0-1 range

        }

        if (commandContainer.JumpCommandDown)
        {
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);

            if (groundChecker.IsGrounded)
            {
                myRigidbody.AddForce(Vector3.up * jumpForce);
                onChargeJump.Invoke(jumpCharge);
            }
            
            jumpCharge = 0f;
        }
    }
}
