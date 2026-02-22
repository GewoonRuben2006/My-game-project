using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float damageCooldown = 1f;
    private float lastDamageTime;
    private Transform player;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("EnemyMovement: Player not found. Make sure Player is tagged correctly.");
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = ((Vector2)player.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

   void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                lastDamageTime = Time.time;
            }
        }
    }
}
}
