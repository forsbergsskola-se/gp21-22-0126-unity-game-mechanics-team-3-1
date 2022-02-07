using System;
using UnityEngine;

public class MoveTowardsPlayerAI : MonoBehaviour
{
    private GameObject Player;
    private CommandContainer commandContainer;
    private Transform playerTransform;
    [SerializeField] private float playerNearDistance = 10f;

    private void Start()
    {
        commandContainer = GetComponentInChildren<CommandContainer>();
        Player = FindObjectOfType<PlayerIdentifier>().gameObject; // looks for a component of type PlayerIdentifierComponent using Generics
        playerTransform = Player.transform;
    }

    private void Update()
    {
        //var proximityToPlayer = Vector3.Distance(transform.position, playerTransform.position)
        
        var proximityToPlayer = Mathf.Abs(playerTransform.position.x - transform.position.x);

        // only moves if close enough to Player
        if (proximityToPlayer > playerNearDistance)
        {
            commandContainer.walkCommand = 0;
            return;
        }
        
        var directionToPlayer = (playerTransform.position - transform.position).normalized;
        
        //directionToPlayer.Normalize(); alt way of normalizing via a method
        var horizontalDirectionToPlayer = directionToPlayer.x;

        // Var horizontalDirectionToPlayer = Mathf.Sign(directionToPlayer.x); //if positive returns 1, negative returns -1 - always keeps enemy at max speed

        commandContainer.walkCommand = horizontalDirectionToPlayer;
    }
}
