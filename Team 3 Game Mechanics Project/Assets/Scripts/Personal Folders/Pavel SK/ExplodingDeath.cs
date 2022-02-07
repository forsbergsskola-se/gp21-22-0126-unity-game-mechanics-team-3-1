using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingDeath : MonoBehaviour{
    public Explode boom;
    Health health;


    void Start(){
        boom = GetComponent<Explode>();
        health = GetComponent<Health>();
    }

    void Update(){
        
        //When health 0 die
        if (health.MaxHealth <= 0){
            
        }
        
        //When dead explode
            //deal dmg to anything
            
    }
}
