using UnityEngine;

public class CommandContainer : MonoBehaviour
{
    // these fields are visible in the inspector, which can be useful for testing.
    // But in some cases we might want to use {HideInInspector} or getters/setters to hide these fields
    
    public float walkCommand;
    public bool JumpCommandDown;
    public bool JumpCommandUp;
    public bool JumpCommand;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
