using UnityEngine;
[CreateAssetMenu(fileName = "New Custom Dash Velocity", menuName = "Our Scriptable Objects/Movement/Dash Speed")]
public class DashSpeedSO : ScriptableObject
{
    [SerializeField] private float dashVelocity = 18f;
    public float DashVelocity => dashVelocity;
}
