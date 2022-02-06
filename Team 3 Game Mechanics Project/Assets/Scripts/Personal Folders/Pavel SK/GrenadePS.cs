using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePS : MonoBehaviour
{

    public float delay = 3f;
    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    void Start(){
        countdown = delay;
    }

    void Update(){
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
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
        //Add force
        //Damage
        //Remove grenade
        Destroy(gameObject);
    }
}
