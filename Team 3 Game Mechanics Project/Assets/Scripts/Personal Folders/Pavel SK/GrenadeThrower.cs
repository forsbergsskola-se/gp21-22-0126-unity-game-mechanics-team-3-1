using UnityEngine;

public class GrenadeThrower : MonoBehaviour{

    [SerializeField] float throwForce = 40f;
    [SerializeField] GameObject grenadePrefab;
    private Vector3 walkDirection = Vector3.zero;
    private Vector3 inputDirection;
    
    void Update()
    {
        // Harry: added these vectors to judge if moving
        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        walkDirection = inputDirection;
        
        if (Input.GetMouseButtonDown(0)){
            ThrowGrenade();
        }
    }

    void ThrowGrenade(){
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        
        // Harry: shoot direction defaults at right, then is based on input direction if moving
        if (walkDirection == Vector3.zero)
            rb.AddForce(transform.right * throwForce, ForceMode.VelocityChange);
        else
        {
            rb.AddForce(inputDirection * throwForce, ForceMode.VelocityChange);
        }
    }
}
