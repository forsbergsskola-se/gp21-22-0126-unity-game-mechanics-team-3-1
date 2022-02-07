using System;
using UnityEngine;

public class UpgradeUnlockHH : MonoBehaviour
{
    private DashHH dash;
    private GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerIdentifier>().gameObject;
        dash = player.GetComponent<DashHH>();
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
        
        // De-active this gameObject
        gameObject.SetActive(false);
    }
}
