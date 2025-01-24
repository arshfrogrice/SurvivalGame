using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public HungerBar hungerBar; // Reference to the HungerBar script
    public HealthBarScript healthBar; // Reference to the HealthBar script
    public Leaderboard leaderboard;


    public int maxHunger = 100; // Max Hunger value
    public int maxHealth = 100; // Max Health value

    public float currentHunger; // Current Hunger value (float for smoother operations)
    public float currentHealth; // Current Health value

    public float hungerDecreaseRate = 1f; // Time interval (in seconds) to decrease hunger while walking
    private float hungerTimer; // Timer for hunger decrease

    public float healthDecreaseRate = 1f; // Amount of health to decrease when hunger is 0
    public float healthDecreaseInterval = 2f; // Time interval for health decrease when hunger is 0
    private float healthTimer; // Timer for health decrease
    public float healthIncreaseRate = 0.1f; // Rate at which health increases when hunger increases

    private CharacterController characterController; // For checking player movement
    public bool isMoving; // This flag tracks player movement, assume it's set elsewhere in your code
    public static PlayerStatsManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        // Initialize hunger and health
        currentHunger = maxHunger;
        currentHealth = maxHealth;

        // Ensure sliders are set up properly
        hungerBar.Setmaxhealth(maxHunger);
        hungerBar.SetHealth((int)currentHunger);

        healthBar.Setmaxhealth(maxHealth);
        healthBar.SetHealth((int)currentHealth);

        // Get the CharacterController to detect movement
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController not found on this GameObject!");
        }
    }

    void Update()
    {
        HandleHunger();
        HandleHealth();
    }

    void HandleHunger()
    {
        // Decrease hunger only when the player is moving (using isMoving)
        if (isMoving)
        {
            hungerTimer += Time.deltaTime;
            if (hungerTimer >= hungerDecreaseRate)
            {
                DecreaseHunger(1); // Decrease hunger by 1 unit
                hungerTimer = 0f; // Reset the timer after hunger decrease
            }
        }
    }

    void HandleHealth()
    {
        // If hunger is 0, gradually decrease health over time
        if (currentHunger <= 0)
        {
            // Gradually decrease health based on time
            healthTimer += Time.deltaTime;
            if (healthTimer >= healthDecreaseInterval)
            {
                DecreaseHealth(healthDecreaseRate); // Decrease health by the healthDecreaseRate
                healthTimer = 0f; // Reset the health timer
            }
        }
    }

    public void DecreaseHunger(int amount)
    {
        currentHunger = Mathf.Max(0, currentHunger - amount); // Ensure hunger doesn't go below 0
        hungerBar.SetHealth((int)currentHunger); // Update the slider
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount); // Ensure health doesn't go below 0
        healthBar.SetHealth((int)currentHealth); // Update the slider

        if (currentHealth <= 0)
        {
            leaderboard.EndGame();
            Debug.Log("Player has died!");
            // Add death or respawn logic here
        }
    }

    public void IncreaseHunger(int amount)
    {
        currentHunger = Mathf.Min(maxHunger, currentHunger + amount); // Ensure hunger doesn't exceed max
        hungerBar.SetHealth((int)currentHunger); // Update the slider

        if (currentHunger > 0)
        {
            StartCoroutine(IncreaseHealthOverTime());  // Start health increase over time
        }
    }

    private IEnumerator IncreaseHealthOverTime()
    {
        while (currentHunger > 0 && currentHealth < maxHealth)
        {
            IncreaseHealth(healthIncreaseRate);  // Increase health by a fixed rate
            yield return new WaitForSeconds(1f);  // Wait 1 second before increasing again
        }
    }

    public void IncreaseHealth(float amount) // Changed to float for health increase rate
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount); // Ensure health doesn't exceed max
        healthBar.SetHealth((int)currentHealth); // Update the slider
    }

    // New method to handle temperature damage
    public void TakeDamage(float amount)
    {
        DecreaseHealth(amount);
    }
    


}

