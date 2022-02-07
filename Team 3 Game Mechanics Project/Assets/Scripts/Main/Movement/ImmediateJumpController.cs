using UnityEngine;
using UnityEngine.Events;

public class ImmediateJumpController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private CommandContainer commandContainer;
    private GroundChecker groundChecker;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private UnityEvent onJump;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        commandContainer = GetComponentInChildren<CommandContainer>();
        groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        //Apply jump force
        //Preferably interact with physics in FixedUpdate() 
        if (!commandContainer.JumpCommandDown || !groundChecker.IsGrounded) return;
        myRigidbody.AddForce(Vector3.up * jumpForce);
        onJump.Invoke();
    }
}
