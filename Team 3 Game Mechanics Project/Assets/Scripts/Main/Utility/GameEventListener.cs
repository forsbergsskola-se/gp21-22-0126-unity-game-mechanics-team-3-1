using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
   [SerializeField] private GameEvent gameEvent;
   
   [SerializeField] private UnityEvent onGameEvent; // should get invoked when GameEvent emits

   private void OnEnable()
   {
      gameEvent.OnGameEvent += InvokeUnityEvent; // subscribe to the gameEvent.OnEvent action
   }
   
   private void OnDisable()
   {
      gameEvent.OnGameEvent -= InvokeUnityEvent; // unsubscribe from the gameEvent.OnEvent action
   }

   private void InvokeUnityEvent()
   {
      onGameEvent.Invoke();
   }
}
