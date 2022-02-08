using System.Collections;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    private bool IsDead;
    [SerializeField] public int MaxHealth;
    [HideInInspector] public int currentHealth;
    private int healthDifference;
    private int value;
    public float damageCooldownTime;
    private bool invulnerable = false;
    
    // Text Mesh Pro elements
    private TMP_Text PlayerHealthText;
    private TMP_Text EnemyHealthText;

    public void Awake()
    {
        //Sets Health to max on spawn
        currentHealth = MaxHealth;
        IsDead = false;
    }

    private void Update()
    {
        //health can't exceed MaxHealth
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
            
            // Health UI corrected
            if (!GetComponent<PlayerIdentifier>())
            { 
                UpdateEnemyHealthText();
            }
            else if (GetComponent<PlayerIdentifier>())
            {
                UpdatePlayerHealthText();
            }
        }

        // Death logic
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            IsDead = true;
            Debug.Log($"{name} is dead!");
        }
        
        // Death Clean-Up
        switch (IsDead)
        {
            // Enemies disabled
            case true when !GetComponent<PlayerIdentifier>():
                gameObject.SetActive(false);
                break;
            
            // Player death resets scene
            case true when GetComponent<PlayerIdentifier>():
                StartCoroutine(GetComponent<ResetHH>().Reset());
                break;
        }
    }

    public void TakeDamage(int damageCaused)
    {
        // can't take damage while invulnerable
        if (invulnerable) return;
        StartCoroutine(DamageCooldown());
        
        // take damage logic
        currentHealth = (currentHealth - damageCaused);
        
        // Update Health Text UI
        if (!GetComponent<PlayerIdentifier>())
        { 
            UpdateEnemyHealthText();
        }
        else if (GetComponent<PlayerIdentifier>())
        {
            UpdatePlayerHealthText();
        }
    }

    public void Heal(int healAmount)
    {
        // can't heal if full health
        if (currentHealth >= MaxHealth) return;
        
        // heal logic
        currentHealth = currentHealth+= healAmount;
        UpdatePlayerHealthText();
    }

    private IEnumerator DamageCooldown()
    {
        // invulnerable to damage while WaitForSeconds active
        invulnerable = true;
        yield return new WaitForSeconds(damageCooldownTime);
        invulnerable = false;
    }

    // Only triggered when affected by damage or healing
    private void UpdatePlayerHealthText()
    {
        if (!GetComponent<PlayerIdentifier>()) return;
        PlayerHealthText = GameObject.Find("Health Text").GetComponent<TMP_Text>();
        PlayerHealthText.text = $"HEALTH: {currentHealth}";
    }
    
    // Only triggered when affected by damage
    private void UpdateEnemyHealthText()
    {
        EnemyHealthText = GetComponentInChildren<TMP_Text>();
        EnemyHealthText.text = $"HEALTH: {currentHealth}";
    }
}
