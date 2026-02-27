using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemiesKilled = 0;
    public int killsForUpgrade = 10;

    public GameObject upgradePanel;

    void Awake()
    {
        Instance = this;
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled % killsForUpgrade == 0)
        {
            ShowUpgradeMenu();
        }
    }

    void ShowUpgradeMenu()
    {
        Time.timeScale = 0f; // Pause game
        upgradePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        upgradePanel.SetActive(false);
    }
}
