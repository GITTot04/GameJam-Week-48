using UnityEngine;
using System.Collections;

public class BigBadBoss : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform player;
    public float speed = 3f;
    public float OldSpeed;
    public Collider2D attackCollider;

    [Header("Melee Settings")]
    public float attackRange = 2f;
    public float attackDuration = 1f;
    public float attackDelay = 1f;
    public float attackCooldown = 3f;  
    private bool isAttacking = false;
    private float lastAttackTime = -Mathf.Infinity;

    [Header("Projectile Settings")]
    public GameObject projectilePrefab;  
    public float fireInterval = 10f;    
    public float stopFireDuration = 3f;
    private float lastFireTime = -Mathf.Infinity;


    void Start()
    {
        lastFireTime = Time.time;
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            MoveTowardsPlayer();
        }
        else if (!isAttacking && Time.time >= lastAttackTime + attackCooldown) 
        {
            StopMovement();
            StartCoroutine(AttackPlayer());
        }

        if (Time.time >= lastFireTime + fireInterval)
        {
            StartCoroutine(FireProjectiles());
            lastFireTime = Time.time;
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void StopMovement()
    {
        speed = OldSpeed;
        speed = 0f;  
    }

    private void ResumeMovement()
    {
        speed = OldSpeed;  
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackDelay);
        attackCollider.enabled = true;
        lastAttackTime = Time.time;
        yield return new WaitForSeconds(attackDuration);
        attackCollider.enabled = false;
        isAttacking = false;
        ResumeMovement();
    }

    private IEnumerator FireProjectiles()
    {
        StopMovement();

        FireProjectile(Vector3.left);
        FireProjectile(Vector3.right);

        yield return new WaitForSeconds(stopFireDuration);

        ResumeMovement();
    }

    private void FireProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.velocity = direction * 5f;

            Destroy(projectile, 5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerWeapon")
        {
            GameObject.Find("BossHealthManager").GetComponent<BossHealthManager>().TakeDamage(20);
            Debug.Log("AV");
        }
    }
}