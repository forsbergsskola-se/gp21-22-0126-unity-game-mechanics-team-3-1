using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Utility/ Game Event")]

public class GameEvent : ScriptableObject
{
    public Action OnGameEvent; // no data passed along with this event
}
