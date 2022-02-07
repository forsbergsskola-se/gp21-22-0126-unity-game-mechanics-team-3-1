using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private bool IsDead = false;
    [SerializeField] private int MaxHealth;
    private float currentHealth;
    private float health;
    private int healthDifference;
    private int value;
    public float damageCooldownTime;
    private bool invulnerable = false;

    public void Awake()
    {
        currentHealth = MaxHealth;
        health = MaxHealth;
    }

    private void Update()
    {
        currentHealth = health;
        
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
        health = (health - damageCaused);
        Debug.Log($"{name} took {damageCaused} damage");
        Debug.Log($"{name}'s current health = {currentHealth}");
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
    }

    private IEnumerator DamageCooldown()
    {
        invulnerable = true;
        yield return new WaitForSeconds(damageCooldownTime);
        invulnerable = false;
    }
}
