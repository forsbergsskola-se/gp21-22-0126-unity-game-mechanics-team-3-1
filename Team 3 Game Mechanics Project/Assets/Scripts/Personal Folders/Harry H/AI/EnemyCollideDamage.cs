using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollideDamage : MonoBehaviour
{
    private GameObject player;
    public int contactDamage = 10;
    private bool damageDuringCollisionStay;

    private void Awake()
    {
        player = FindObjectOfType<PlayerIdentifier>().gameObject;
        damageDuringCollisionStay = false;
    }

    // Damage triggered on collision if takeDamage cooldown inactive
    private void OnCollisionEnter(Collision collision)
    {
        CheckIfCanDealDamage(collision);
    }

    // Continues to cause damage while collision remains active (Player hasn't moved away)
    // Only causes damage though if takeDamage cooldown inactive and stay bool is true

    private void OnCollisionStay(Collision collision)
    {
        CheckIfCanDealDamage(collision);
    }
    
    
    // resets bool on Exit
    private void OnCollisionExit(Collision other)
    {
        damageDuringCollisionStay = false;
    }

    
    
    private void CheckIfCanDealDamage(Collision collision)
    {
        // won't cause damage to other enemies, only Player
        if (collision.gameObject != player) return;
        
        // toggles bool on Collision Enter so no double damage from Collision Stay
        // this bool is set to false on Collision exit to reset this check
        Debug.Log($"colliding with {player}");
        player.GetComponent<Health>().TakeDamage(contactDamage);
        damageDuringCollisionStay = true;
    }

}
