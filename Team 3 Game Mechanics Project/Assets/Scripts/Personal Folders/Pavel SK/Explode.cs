using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    
    [SerializeField] float radius = 5f;
    [SerializeField] float force = 700f;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] int damageValue = 25;
    
    
    internal void ExplodeSomething(){
        Debug.Log("BOOM");
        
        //show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        
        //Get nearby objects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {
            
            //destroy object
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null){
                dest.Destroy();
            }
        }
        
        //Get nearby objects
        Collider[] collidersToMove= Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove){
            
            //Add blast force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            
            // Harry: added take damage logic
            if (nearbyObject.CompareTag("Enemy"))
            {
                nearbyObject.GetComponent<Health>().TakeDamage(damageValue);
            }
        }
        
        //Remove grenade
        Destroy(gameObject);
    }
}
