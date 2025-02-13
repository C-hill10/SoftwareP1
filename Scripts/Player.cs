
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text healthText;
      // Variables related to projectiles
    public GameObject projectilePrefab;
    public int health;
    public int maxHealth;
    public int minHealth;
    public float jumpForce = 10f;
    public float speed;
    private float input;


    Vector2 move;
    Rigidbody2D rb;
    Animator anim;
    bool directionRight = true;
   private bool isGrounded = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        healthText.text = health.ToString();  
    }

    private void Update() {

        if(input != 0) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if(input > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
            directionRight = true;
        } else if(input < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
            directionRight = false;
        }

           if(Input.GetKeyDown(KeyCode.C))
        {
           Launch();
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        input = Input.GetAxisRaw("Horizontal");
        
        rb.linearVelocity = new Vector2(input * speed, rb.linearVelocity.y);
    }
    public void TakeDamage(int damageAmount){
        health -= damageAmount;
        healthText.text = health.ToString();  
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
    public void ChangeHealth(int amount)
    {
        if(health < maxHealth){
            health += amount;
            healthText.text = health.ToString();  
        }
    }

    void Launch()
    {
        Vector2 moveRight = new Vector2(2,0);
        Vector2 moveLeft = new Vector2(-2,0);

            if(directionRight)
            {
                GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.right * 0.5f, Quaternion.identity);
                Projectile projectile = projectileObject.GetComponent<Projectile>();
                projectile.Launch(moveRight, 600);
            }
            else
            {
                GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.left * 0.5f, Quaternion.identity);
                Projectile projectile = projectileObject.GetComponent<Projectile>();
                projectile.Launch(moveLeft, 600);
            }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }   

}
