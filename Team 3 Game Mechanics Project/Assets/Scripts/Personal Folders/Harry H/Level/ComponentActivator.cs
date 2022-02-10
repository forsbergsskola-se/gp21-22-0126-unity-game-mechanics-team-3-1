using UnityEngine;
public class ComponentActivator : MonoBehaviour
{
   public string ScriptToToggle;
   private GameObject Player;
   private Behaviour component;
   private GameObject dashUI;
   private Vector3 dashUISpawnPos;
   private void Awake()
   {
      // Disables dashUI if dash not yet unlocked - commented out as a bit buggy
      
      /*dashUI = GameObject.Find("Energy Bar").gameObject;
      dashUISpawnPos = dashUI.transform.position;
      dashUI.transform.position = new Vector3(1000, 1000, 0);*/

      
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

      // enables Dash UI
      //dashUI.transform.position = dashUISpawnPos;

      // Updates spawn position to this checkpoint's X Vector location
      Player.GetComponent<ResetHH>().spawnPos.x = transform.position.x;
      
      // enable on trigger enter and deactivate this gameObject so script doesn't check on repeat trigger entries
      component.enabled = true;
      gameObject.SetActive(false);
   }
}
