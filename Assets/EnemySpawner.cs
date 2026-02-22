using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy to spawn
    public float spawnInterval = 3f; // seconds between spawns
    public int maxEnemies = 10; // max enemies alive at once
    public Vector2 spawnAreaMin; // bottom-left of spawn area
    public Vector2 spawnAreaMax; // top-right of spawn area

    private float nextSpawnTime;

    void Update()
    {
        // Count current enemies in the scene
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Time to spawn and we haven't reached max
        if (Time.time >= nextSpawnTime && currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Random position in the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPos = new Vector3(x, y, 0f);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
