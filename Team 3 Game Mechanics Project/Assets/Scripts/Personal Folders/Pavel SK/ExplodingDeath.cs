using UnityEngine;

public class ExplodingDeath : MonoBehaviour{
    
    public Explode boom;
    Health health;
    


    void Start(){
        boom = GetComponent<Explode>();
        health = GetComponent<Health>();
    }

    void Update(){
        
        //When health 0 die and explode
        if (health.currentHealth <= 0f){
            boom.ExplodeSomething();
            Debug.Log("I exploded");
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Colliding and exploding with player");
            boom.ExplodeSomething();
        }
    }
}
