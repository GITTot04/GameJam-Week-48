using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    float tid;
    public int speed;
    public int jumpSpeed;
    Vector3 moveLeft = new Vector3(-1, 0, 0);
    Vector3 moveRight = new Vector3(1, 0, 0);
    public bool startDirection;
    bool currentDirection;
    bool isChasing = false;
    GameObject player;
    bool IsGrounded = true;
    Rigidbody2D rb;
    int amountOfCollisionsWithGround;
    GameObject atkHitboxLeft;
    GameObject atkHitboxRight;
    public float atkCD;
    float timeSinceAtk;
    int hp = 3;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = startDirection;
        atkHitboxLeft = transform.GetChild(0).gameObject;
        atkHitboxRight = transform.GetChild(1).gameObject;
        atkHitboxLeft.SetActive(false);
        atkHitboxRight.SetActive(false);
    }
    private void Update()
    {
        timeSinceAtk += Time.deltaTime;
        if (!isChasing)
        {
            tid += Time.deltaTime;
            if (currentDirection)
            {
                transform.Translate(moveRight * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(moveLeft * speed * Time.deltaTime);
            }
            if (tid >= 4f)
            {
                currentDirection = !currentDirection;
                tid = 0f;
            }
        }
        else
        {
            if (timeSinceAtk > atkCD)
            {
                if ((player.transform.position.x < transform.position.x - 1.5f || player.transform.position.x > transform.position.x + 1.5f) && player.transform.position.y > transform.position.y + 0.1 && IsGrounded)
                {
                    rb.AddForce(new Vector2(0, jumpSpeed));
                    IsGrounded = false;
                }
                if (player.transform.position.x < transform.position.x - 1.5f)
                {
                    transform.Translate(moveLeft * speed * Time.deltaTime);
                }
                else if (player.transform.position.x > transform.position.x + 1.5f)
                {
                    transform.Translate(moveRight * speed * Time.deltaTime);
                }
                else
                {
                    if (player.transform.position.x < transform.position.x)
                    {
                        StartCoroutine(Attack(false));
                    }
                    else
                    {
                        StartCoroutine(Attack(true));
                    }
                    timeSinceAtk = 0;
                }
            }
        }
    }
    private void LateUpdate()
    {
        if (amountOfCollisionsWithGround == 2 && IsGrounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            IsGrounded = false;
        }
        amountOfCollisionsWithGround = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isChasing)
        {
            player = collision.gameObject;
            isChasing = true;
        }
        if (collision.tag == "PlayerWeapon")
        {
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND")
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND")
        {
            amountOfCollisionsWithGround++;
        }
    }

    IEnumerator Attack(bool attackDirection)
    {
        if (attackDirection)
        {
            atkHitboxRight.SetActive(true);
        }
        else
        {
            atkHitboxLeft.SetActive(true);
        }
        yield return new WaitForFixedUpdate();
        atkHitboxLeft.SetActive(false);
        atkHitboxRight.SetActive(false);
    }
}
