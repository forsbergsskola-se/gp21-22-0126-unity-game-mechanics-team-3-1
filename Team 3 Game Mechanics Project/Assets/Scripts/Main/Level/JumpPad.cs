using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1500f;
    
    private void OnTriggerEnter(Collider other)
    {
        // Null check with early return
        //var otherRigidbody = other.GetComponent<Rigidbody>();
        // if (otherRigidbody == null)
        //    return; 
        // otherRigidbody.AddForce(transform.up * jumpForce);
        
        // Null check using null propagation operator
        other.GetComponent<Rigidbody>()?.AddForce(transform.up * jumpForce);
    }
}
