using System;
using UnityEngine;

public class MoveTowardsPlayerAI : MonoBehaviour
{
    private GameObject Player;
    private CommandContainer commandContainer;
    private Transform playerTransform;

    private void Start()
    {
        commandContainer = GetComponentInChildren<CommandContainer>();
        
        // looks for a component of type PlayerIdentifierComponent using Generics
        Player = FindObjectOfType<PlayerIdentifier>().gameObject;
        playerTransform = Player.transform;
    }

    private void Update()
    {
        var directionToPlayer = (playerTransform.position - transform.position).normalized;
        
        //directionToPlayer.Normalize(); alt way of normalizing via a method
        var horizontalDirectionToPlayer = directionToPlayer.x;

        // Var horizontalDirectionToPlayer = Mathf.Sign(directionToPlayer.x); //if positive returns 1, negative returns -1 - always keeps enemy at max speed
        commandContainer.walkCommand = horizontalDirectionToPlayer;
    }
}
