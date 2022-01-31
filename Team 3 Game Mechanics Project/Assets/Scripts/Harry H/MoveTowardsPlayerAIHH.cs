
using System;
using UnityEngine;

public class MoveTowardsPlayerAIHH : MonoBehaviour
{
    private GameObject Player;
    private CommandContainerHH commandContainer;
    private Transform playerTransform;

    private void Awake()
    {
        commandContainer = this.gameObject.GetComponent<CommandContainerHH>();
        Player = GameObject.FindWithTag("Player");
        playerTransform = Player.transform;
    }

    private void Update()
    {
        var directionToPlayer = (playerTransform.position - transform.position).normalized;
        
        //directionToPlayer.Normalize(); alt way of normalizing via a method
        var horizontalDirectionToPlayer = directionToPlayer.x;

        commandContainer.walkCommand = horizontalDirectionToPlayer;
    }
}
