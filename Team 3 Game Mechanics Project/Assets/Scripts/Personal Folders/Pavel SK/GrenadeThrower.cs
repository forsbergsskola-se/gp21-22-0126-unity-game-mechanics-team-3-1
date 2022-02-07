using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour{

    [SerializeField] float throwForce = 40f;
    [SerializeField] GameObject grenadePrefab;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            ThrowGrenade();
        }
    }

    void ThrowGrenade(){
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.right * throwForce, ForceMode.VelocityChange);
    }
}
