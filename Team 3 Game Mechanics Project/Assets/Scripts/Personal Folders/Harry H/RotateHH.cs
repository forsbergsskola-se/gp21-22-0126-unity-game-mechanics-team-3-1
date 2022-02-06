using UnityEngine;

public class RotateHH : MonoBehaviour
{
    public float rotateSpeed = 3f;
    private void Update()
    {
        transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime * rotateSpeed);
    }
}
