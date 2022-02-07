using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePS : MonoBehaviour
{

    [SerializeField] float delay = 3f;
    public Explode boom;

    float _countdown;
    bool hasExploded = false;

    

    void Start(){
        _countdown = delay;
        boom = GetComponent<Explode>();
    }

    void Update(){
        _countdown -= Time.deltaTime;
        if (_countdown <= 0f && !hasExploded){
            boom.ExplodeSomething();
            hasExploded = true;
            
        }
    }
    
}
