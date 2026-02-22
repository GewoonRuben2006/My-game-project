using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f; // seconds between shots

    private float nextFireTime;

    void Update()
    {
        // Shoot automatically when cooldown passes
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab not assigned!");
            return;
        }

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
