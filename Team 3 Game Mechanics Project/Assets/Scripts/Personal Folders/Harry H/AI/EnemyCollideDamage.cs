using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollideDamage : MonoBehaviour
{
    private GameObject player;
    public int contactDamage = 10;
    private bool damageDuringCollisionStay = false;

    private void Awake()
    {
        player = FindObjectOfType<PlayerIdentifier>().gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckIfCanDealDamage(collision);
    }

    private void OnCollisionExit(Collision other)
    {
        damageDuringCollisionStay = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        CheckIfCanDealDamage(collision);
    }
    
    private void CheckIfCanDealDamage(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log($"colliding with {player}");
            player.GetComponent<Health>().TakeDamage(contactDamage);
            damageDuringCollisionStay = true;
        }
    }

}
