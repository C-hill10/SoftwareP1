using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public int minSpeed = 1;
    public int maxSpeed = 5;
    public int damage;
    private float speed;

    Player playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
