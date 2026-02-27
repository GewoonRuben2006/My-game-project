using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public Health playerHealth;
    public PlayerShooting playerShooting;

    public void HealPlayer()
    {
        playerHealth.TakeDamage(-2); // heal 2
        GameManager.Instance.ResumeGame();
    }

    public void IncreaseFireRate()
    {
        playerShooting.fireRate *= 0.8f; // faster shooting
        GameManager.Instance.ResumeGame();
    }
}
