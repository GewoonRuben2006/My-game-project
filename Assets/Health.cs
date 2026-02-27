using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public Slider healthSlider;

    void Awake()
    {
        currentHealth = maxHealth;
    
        if (healthSlider != null) {
             healthSlider.maxValue = maxHealth;
             healthSlider.value = currentHealth;
            }
    }

    public void TakeDamage(int amount)
     {
        currentHealth -= amount;

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Check what type of object this is
        if (CompareTag("Player"))
        {
            // Player dies → maybe restart scene, show Game Over, etc.
            Debug.Log("Player died!");
            // For now just destroy, but you can replace with scene reload
            Destroy(gameObject);
        }
        else  if (CompareTag("Enemy"))
    {
        GameManager.Instance.EnemyKilled();
        Destroy(gameObject);
    }
        else
        {
            // Anything else
            Destroy(gameObject);
        }
    }
}
