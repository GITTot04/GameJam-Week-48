using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f;
    public float attackRange = 2f;
    public Collider2D attackCollider; 
<<<<<<< Updated upstream
    
=======

    private void Start()
    {
        if (attackCollider == null)
        {
            Debug.LogWarning("Attack collider not assigned! Please add and assign a trigger collider.");
        }
    }

>>>>>>> Stashed changes
    private void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            StopMovement();
            AttackPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        Debug.Log("Boss is approaching the player...");
    }

    private void StopMovement()
    {
        Debug.Log("Boss has stopped moving.");
    }

    private void AttackPlayer()
    {
        Debug.Log("Boss swings his sword!");
    }

<<<<<<< Updated upstream
=======
    // Detect if the player enters the attack zone
>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLISION");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player was hit by the boss!");
        }
    }
}




