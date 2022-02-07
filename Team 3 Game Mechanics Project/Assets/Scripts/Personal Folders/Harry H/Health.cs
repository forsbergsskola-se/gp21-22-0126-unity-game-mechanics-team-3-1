using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private bool IsDead;
    [SerializeField] public int MaxHealth;
    [HideInInspector] public float currentHealth;
    private int healthDifference;
    private int value;
    public float damageCooldownTime;
    private bool invulnerable = false;

    public void Awake()
    {
        currentHealth = MaxHealth;
        IsDead = false;
    }

    private void Update()
    {
        Mathf.Clamp(currentHealth, 0, MaxHealth);
        
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        
        if (currentHealth <= 0)
        {
            IsDead = true;
            Debug.Log($"{name} is dead!");
            if (!GetComponent<PlayerIdentifier>())
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(int damageCaused)
    {
        if (invulnerable) return;
        StartCoroutine(DamageCooldown());
        currentHealth = (currentHealth - damageCaused);
        Debug.Log($"{name} took {damageCaused} damage");
        Debug.Log($"{name}'s current health = {currentHealth}");
    }

    public void Heal(int healAmount)
    {
        currentHealth = currentHealth+= healAmount;
        Debug.Log($"{name} healed by {healAmount} points");
        Debug.Log($"{name}'s curren health: {currentHealth}");
    }

    private IEnumerator DamageCooldown()
    {
        invulnerable = true;
        yield return new WaitForSeconds(damageCooldownTime);
        invulnerable = false;
    }
}
