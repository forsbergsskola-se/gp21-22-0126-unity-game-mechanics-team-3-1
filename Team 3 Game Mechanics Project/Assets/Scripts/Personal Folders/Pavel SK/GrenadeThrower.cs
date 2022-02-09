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
        
        // Harry changed from transform.Right to new vector 3 using horizontal input
        rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * throwForce, ForceMode.VelocityChange);
    }
}
