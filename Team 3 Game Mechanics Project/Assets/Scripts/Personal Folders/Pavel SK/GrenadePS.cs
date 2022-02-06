using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePS : MonoBehaviour
{

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    public GameObject explosionEffect;

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
        
        //get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            //Add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            //Damage
        }
        
        //Remove grenade
        Destroy(gameObject);
    }
}
