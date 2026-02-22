using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

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
        else if (CompareTag("Enemy"))
        {
            // Enemy dies → just destroy enemy
            Destroy(gameObject);
        }
        else
        {
            // Anything else
            Destroy(gameObject);
        }
    }
}
