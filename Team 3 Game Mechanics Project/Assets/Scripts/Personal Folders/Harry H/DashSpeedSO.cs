using UnityEngine;
[CreateAssetMenu(fileName = "New Custom Dash Velocity", menuName = "Our Scriptable Objects/Movement/Dash Speed")]
public class DashSpeedSO : ScriptableObject
{
    [SerializeField] private float dashVelocity = 18f;
    [SerializeField] private float dashCooldownTime = 3f;
    public float DashVelocity => dashVelocity;
    public float DashCoolDownTime => dashCooldownTime; }
