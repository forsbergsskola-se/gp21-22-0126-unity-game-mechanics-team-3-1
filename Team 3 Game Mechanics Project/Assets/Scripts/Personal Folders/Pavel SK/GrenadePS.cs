using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePS : MonoBehaviour
{

    [SerializeField] float delay = 3f;
    [SerializeField] float radius = 5f;
    [SerializeField] float force = 700f;
    [SerializeField] GameObject explosionEffect;

    float _countdown;
    bool hasExploded = false;

    void Start(){
        _countdown = delay;
    }

    void Update(){
        _countdown -= Time.deltaTime;
        if (_countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode(){
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
        }
        
        //Remove grenade
        Destroy(gameObject);
    }
}
