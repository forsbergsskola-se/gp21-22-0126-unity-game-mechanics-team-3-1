using UnityEngine;
public class ComponentActivator : MonoBehaviour
{
   public string ScriptToToggle;
   private GameObject Player;
   private Behaviour component;
   private void Awake()
   {
      // Find and disable component specified in inspector
      Player = FindObjectOfType<PlayerIdentifier>().gameObject;
      component = (Player.GetComponent(ScriptToToggle) as MonoBehaviour);
      component.enabled = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      // null ref return checks
      if (other.gameObject != Player) return;
      if (component == null) return;
      
      // enable on trigger enter and deactivate this gameObject so script doesn't check on repeat trigger entries
      component.enabled = true;
      gameObject.SetActive(false);
   }
}
