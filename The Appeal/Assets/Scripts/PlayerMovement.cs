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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WIN")
        {
            WinScreen.SetActive(true);
            SceneManager.LoadScene(sceneName);
        }
        else if (collision.gameObject.tag == "DEATH")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        if (collision.gameObject.tag == "Weapon")
        {
            Debug.Log("Av");
        }
    }
}
