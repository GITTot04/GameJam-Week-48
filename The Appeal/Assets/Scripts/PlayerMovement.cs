using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public GameObject WinScreen;
    public string sceneName;
    private Rigidbody2D rb;
    public float jump = 250;
    public bool IsGrounded = false;
    GameObject atkHitboxLeft;
    GameObject atkHitboxRight;
    bool canAttack = true;
    float timeSinceAtk;
    public float atkCD;
    bool facingDirection;
    int hp = 3;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        atkHitboxLeft = transform.GetChild(0).gameObject;
        atkHitboxRight = transform.GetChild(1).gameObject;
        atkHitboxLeft.SetActive(false);
        atkHitboxRight.SetActive(false);
    }

    void Update()
    {
        if (canAttack)
        {
            float x = Input.GetAxisRaw("Horizontal");
            if (x == 1)
            {
                facingDirection = true;
            }
            else if (x == -1)
            {
                facingDirection = false;
            }
            gameObject.transform.Translate(new Vector3(x, 0, 0) * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && IsGrounded)
            {
                rb.AddForce(new Vector2(0, jump));
                IsGrounded = false;
            }
        }
        if (!canAttack)
        {
            timeSinceAtk += Time.deltaTime;
            if (timeSinceAtk >= atkCD)
            {
                canAttack = true;
                timeSinceAtk = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.K) && canAttack)
        {
            StartCoroutine(Attack(facingDirection));
            canAttack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WIN")
        {
            WinScreen.SetActive(true);
            SceneManager.LoadScene(sceneName);
        }
        if (collision.gameObject.tag == "DEATH")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (collision.gameObject.tag == "JUMPBOOST")
        {
            jump = jump+150;
        }
        else if (collision.gameObject.tag == "SPEEDBOOST")
        {
            speed = speed+3;
        }
        else if (collision.gameObject.tag == "POINT")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "GROUND")
        {
            IsGrounded = true;
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            hp -= 1;
            if (hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
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
