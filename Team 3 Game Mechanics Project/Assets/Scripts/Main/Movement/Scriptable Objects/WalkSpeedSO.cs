using UnityEngine;

//SO stands for ScriptableObject
[CreateAssetMenu(fileName = "New Custom Walk Speed", menuName = "Our Scriptable Objects/Movement/Move Speed")]
public class WalkSpeedSO : ScriptableObject
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float chargingWalkSpeedFactor = 0.5f;

    public float WalkSpeed => walkSpeed; //Shorthand lambda expression for a getter for walkSpeed.
    public float ChargingWalkSpeedFactor => chargingWalkSpeedFactor;
}
