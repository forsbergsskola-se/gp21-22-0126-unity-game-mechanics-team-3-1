using UnityEngine;

public class DeathObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.GetComponent<Health>()) return;

        var entireHealth = other.GetComponent<Health>().currentHealth;
        other.GetComponent<Health>().TakeDamage(entireHealth);
    }
}
