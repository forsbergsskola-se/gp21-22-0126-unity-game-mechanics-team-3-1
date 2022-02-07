using UnityEngine;

public class GameEventCallerExample : MonoBehaviour
{
    [SerializeField] private KeyCode keyToCallEvent;
    [SerializeField] private GameEvent gameEventToCall;

    private void Update()
    {
        if (Input.GetKeyDown(keyToCallEvent))
        {
            gameEventToCall.OnGameEvent.Invoke();
        }

    }
}
