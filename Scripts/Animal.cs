using UnityEngine;
using UnityEngine.UI;
public class Animal : MonoBehaviour
{
    public string animalName;
    public bool playerInRange;
    private Animator animator;
    public Slider healthbarSlider;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;

    // New variables for audio
    public AudioClip deathSound;              // Death sound clip
    private AudioSource audioSource;          // Audio source to play sound

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"{animalName} spawned with {currentHealth} health.");
        animator = GetComponent<Animator>();

        // Set up AudioSource if not already attached
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        UpdateHealthBar();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            playerInRange=true;
            healthbarSlider.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            playerInRange=false;
            healthbarSlider.gameObject.SetActive(false);
        }
    }
    private void UpdateHealthBar(){
        healthbarSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (playerInRange)
        {
            currentHealth -= damage;
            UpdateHealthBar();
            Debug.Log($"{animalName} took {damage} damage! Current health: {currentHealth}");

            if (currentHealth <= 0)
            {
                animator.SetTrigger("DIE");
                Die();
            }
            else
            {
                animator.SetTrigger("HIT");
            }
        }
        else
        {
            Debug.Log("Cannot attack: Player is out of range.");
        }
    }
    

    private void Die()
    {
        Debug.Log($"{animalName} has died!");

        // Play the death sound
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        Destroy(gameObject);
    }
}
