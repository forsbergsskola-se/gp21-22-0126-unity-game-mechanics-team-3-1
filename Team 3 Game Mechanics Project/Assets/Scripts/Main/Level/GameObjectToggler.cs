using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectToggler : MonoBehaviour
{
    public void ToggleGameObject()
    {
        // Toggles depending on current active state
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
