using System;
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
    private Vector3 spawnPos;

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
            
            //TODO: Inactivte and activate/reset Player when dead
            // IsDead = false;
            // if (GetComponent<PlayerIdentifier>()){
            //     gameObject.SetActive(true);
            // }
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
                // TODO: gameObject.SetActive(false);
                
                //spawns in correct position
                spawnPos = GetComponent<ResetHH>().spawnPos;
                StartCoroutine(GetComponent<ResetHH>().Reset(spawnPos));
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
        PlayerHealthText.text = $"HEALTH: {Math.Clamp(currentHealth, 0, MaxHealth)}";
        
    }
    
    // Only triggered when affected by damage
    private void UpdateEnemyHealthText()
    {
        EnemyHealthText = GetComponentInChildren<TMP_Text>();
        EnemyHealthText.text = $"{Math.Clamp(currentHealth, 0, MaxHealth)}";
    }
}
