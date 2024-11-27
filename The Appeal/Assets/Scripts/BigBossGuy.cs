using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f;  
    public float attackRange = 2f;  

    private void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }

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
}



