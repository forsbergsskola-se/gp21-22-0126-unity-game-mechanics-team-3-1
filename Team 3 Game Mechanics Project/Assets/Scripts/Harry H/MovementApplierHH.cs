
using System;
using UnityEngine;

public class MovementApplierHH : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public Vector3 StoredVelocity => storedVelocity; //Lambda shorthands for a public getter, but with no setter. Could also be done as private setter, public getter
    private Vector3 storedVelocity;
    private Vector3 storedForce;

    private void Start()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplyVelocity();
        ApplyForce();
    }
    
    private void ApplyVelocity()
    {
        myRigidbody.velocity = storedVelocity;
        storedVelocity = myRigidbody.velocity; // could skip this reset
    }
    
    private void ApplyForce()
    {
        myRigidbody.AddForce(storedForce);
        storedForce = Vector3.zero;
        // storedVelocity = myRigidbody.velocity;
    }

    public void SetHorizontalVelocity(float horizontalVelocity)
    {
        SetVelocity(new Vector3(horizontalVelocity, storedVelocity.y, storedVelocity.z));
    }

    public void SetVelocity(Vector3 velocity)
    {
        storedVelocity = velocity;
    }

    public void AddForce(Vector3 force)
    {
        storedForce += force;
    }
}
