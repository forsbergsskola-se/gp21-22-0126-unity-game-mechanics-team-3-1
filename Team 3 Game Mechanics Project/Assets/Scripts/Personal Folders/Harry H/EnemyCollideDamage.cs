using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollideDamage : MonoBehaviour
{
    private GameObject Player;
    public int contactDamage = 10;
    private bool damageDuringCollisionStay = false;

    private void Awake()
    {
        Player = FindObjectOfType<PlayerIdentifier>().gameObject; // looks for a component of type PlayerIdentifierComponent using Generics

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
        if (collision.gameObject.GetComponent<PlayerIdentifier>())
        {
            Debug.Log($"colliding with {collision.gameObject}");
            collision.gameObject.GetComponent<Health>().TakeDamage(contactDamage);
            damageDuringCollisionStay = true;
        }
    }
}
