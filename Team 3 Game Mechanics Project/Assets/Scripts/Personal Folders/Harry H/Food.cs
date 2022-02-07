using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject player;
    private Health health;
    public int HealPoints;

    private void Awake()
    {
        player = FindObjectOfType<PlayerIdentifier>().gameObject;
        health = player.GetComponent<Health>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player == null){ return;}

        if (health.currentHealth >= health.MaxHealth)
        {
            Debug.Log("Health already full");
            return;
        }
        
        health.Heal(HealPoints);
        gameObject.SetActive(false);
    }
}
