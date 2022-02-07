using System.Collections;
using TMPro;
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
    private TMP_Text PlayerHealthText;

    public void Awake()
    {
        currentHealth = MaxHealth;
        IsDead = false;
    }

    private void Update()
    {
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            IsDead = true;
            Debug.Log($"{name} is dead!");
        }
        
        switch (IsDead)
        {
            case true when !GetComponent<PlayerIdentifier>():
                gameObject.SetActive(false);
                break;
            case true when GetComponent<PlayerIdentifier>():
                StartCoroutine(GetComponent<ResetHH>().Reset());
                break;
        }
    }

    public void TakeDamage(int damageCaused)
    {
        if (invulnerable) return;
        StartCoroutine(DamageCooldown());
        currentHealth = (currentHealth - damageCaused);

        // TODO: Visually show enemy Health
        if (!GetComponent<PlayerIdentifier>())
        { 
            Debug.Log($"{name} took {damageCaused} damage");
            Debug.Log($"{name}'s current health = {currentHealth}");
        }
        else
        {
            UpdatePlayerHealthText();
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth >= MaxHealth) return;
        currentHealth = currentHealth+= healAmount;
        
        UpdatePlayerHealthText();
    }

    private IEnumerator DamageCooldown()
    {
        invulnerable = true;
        yield return new WaitForSeconds(damageCooldownTime);
        invulnerable = false;
    }

    public void UpdatePlayerHealthText()
    {
        if (!GetComponent<PlayerIdentifier>()) return;
        PlayerHealthText = GameObject.Find("Health Text").GetComponent<TMP_Text>();
        PlayerHealthText.text = $"HEALTH: {currentHealth}";
    }
  
}
