using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth=100;
    public int currentHealth;
    public HealthBarScript healthBar;


    void Start(){
        currentHealth=maxHealth;
        healthBar.Setmaxhealth(maxHealth);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(20);
        }
    }
    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}

