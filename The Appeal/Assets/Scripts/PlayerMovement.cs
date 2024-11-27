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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        gameObject.transform.Translate(new Vector3(x, 0, 0) * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb.AddForce(new Vector2(0, jump));
            IsGrounded = false;
            Debug.Log("Jump Triggered: " + IsGrounded);
        }
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DEATH")
        {
            SceneManager.LoadScene(sceneName);
        }
        
        else if (collision.gameObject.tag == "GROUND")
        {
            IsGrounded = true;
            Debug.Log("IsGrounded: " + IsGrounded);
        }
        else if (collision.gameObject.tag == "JUMPBOOST")
        {
            jump = jump+150;
        }
    }
}