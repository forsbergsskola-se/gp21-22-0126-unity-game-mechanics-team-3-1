using UnityEngine;
using System.Collections;
public class CameraControllerHH : MonoBehaviour {
 
    private Transform target;
    public float distance = -8f;
    public float height = -1f;
    public float damping = 10f;
 
    // camera level boundaries
    public float mapXBoundary = 300.0f;
    public float mapYBoundary = 300.0f;

    private Vector3 wantedPosition;
    
    void Awake() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
 
    void LateUpdate() 
    {
        // check if in bounds on X plane
        wantedPosition.x = (wantedPosition.x < mapXBoundary) ? mapXBoundary : wantedPosition.x;
        wantedPosition.x = (wantedPosition.x > mapXBoundary) ? mapXBoundary : wantedPosition.x;
 
        // check if in bounds on  Y plane
        wantedPosition.y = (wantedPosition.y < mapYBoundary) ? mapYBoundary : wantedPosition.y;
        wantedPosition.y = (wantedPosition.y > mapYBoundary) ? mapYBoundary : wantedPosition.y;
        
        // keeps camera at max bounds X point if beyond it
        if (wantedPosition.x > mapXBoundary)
        {
            wantedPosition.x = mapXBoundary;
        }
        
        // keeps camera at max bounds Y point if beyond it
        else if (wantedPosition.y > mapYBoundary)
        {
            wantedPosition.y = mapYBoundary;
        }
        
        // follow Player if not out of bounds
        else
        {
            wantedPosition = target.TransformPoint(0, height, distance);
        }
        
        // damping effect
        transform.position = Vector3.Lerp (transform.position, wantedPosition, (Time.deltaTime * damping));
    }
}