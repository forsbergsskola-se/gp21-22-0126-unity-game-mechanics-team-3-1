using System;
using TMPro;
using UnityEngine;

public class UpgradeUnlockHH : MonoBehaviour
{
    private DashHH dash;
    private GameObject player;
    private GameObject plus;

    private void Awake()
    {
        player = FindObjectOfType<PlayerIdentifier>().gameObject;
        dash = player.GetComponent<DashHH>();
        plus = GameObject.Find("+");
        plus.SetActive(false);
    }

    // Check if Player on collision, logic only executes if so
    private void OnTriggerEnter(Collider other)
    {
        if (player == null)
        {
            return;
        }

        // Unlocks Air Dash if name matches
        if (name != "Dash Skull") return;
        dash.flyingDashUnlocked = true;
        dash.canDash = true;
        Debug.Log("UNLOCKED: Air Dash");
        
        // Adds a plus sign next to Dash UI to visualise upgrade
        plus.SetActive(true);
        
        
        // De-active this gameObject
        gameObject.SetActive(false);
    }
}
