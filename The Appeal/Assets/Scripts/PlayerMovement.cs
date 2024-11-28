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
    public bool doublejump = false;
    public bool allowdoublejump;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        gameObject.transform.Translate(new Vector3(x, 0, 0) * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {   if(doublejump && allowdoublejump){
            rb.AddForce(new Vector2(0, jump));
            allowdoublejump = false;
            } else if (doublejump && !allowdoublejump || !doublejump){
                rb.AddForce(new Vector2(0, jump));
                IsGrounded = false;
            }
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
            allowdoublejump = true;
        }
        else if (collision.gameObject.tag == "JUMPBOOST")
        {
            jump = jump+100;
        }
        else if (collision.gameObject.tag == "SPEEDBOOST")
        {
            speed = speed+3;
        }
        else if (collision.gameObject.tag == "DOUBLEJUMP")
        {
            doublejump = true;
            
        }
    }
}