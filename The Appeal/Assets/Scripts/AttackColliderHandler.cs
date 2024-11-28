using UnityEngine;

public class AttackColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player hit by the attack!");
            // Logic for damaging the player
        }
    }
}