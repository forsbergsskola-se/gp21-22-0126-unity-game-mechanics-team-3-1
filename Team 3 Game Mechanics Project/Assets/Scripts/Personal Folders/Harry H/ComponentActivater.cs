using UnityEngine;
public class ComponentActivater : MonoBehaviour
{
   public string ScriptToToggle;
   private GameObject Player;
   private Component component;
   private void Awake()
   {
      Player = FindObjectOfType<PlayerIdentifier>().gameObject;
      
      var component = (Player.GetComponent(ScriptToToggle) as MonoBehaviour);
      component.enabled = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject != Player) return;
      
      var component = (Player.GetComponent(ScriptToToggle) as MonoBehaviour);
      component.enabled = true;
      gameObject.SetActive(false);
   }
}
