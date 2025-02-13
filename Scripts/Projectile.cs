using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject healthObject;
   Rigidbody2D rigidbody2d;


   // Awake is called when the Projectile GameObject is instantiated
   void Awake()
   {
       rigidbody2d = GetComponent<Rigidbody2D>();
   }

   void Update()
   {
       if(transform.position.magnitude > 100.0f)
       {
           Destroy(gameObject);
       }
   }


   public void Launch(UnityEngine.Vector2 direction, float force)
  {
       rigidbody2d.AddForce(direction * force);
  }


   void OnTriggerEnter2D(Collider2D other)
  {
       Enemy enemy = other.GetComponent<Enemy>();
       EnemyCharacter enemyCharacter = other.GetComponent<EnemyCharacter>();
       if (enemy != null)
           {
                Destroy(enemy.gameObject);
                Destroy(gameObject);
                
                UnityEngine.Vector2 healthPoint = other.transform.position;
            // Instantiate(hazards[random], spawnPoints[randPos].position, Quaternion.identity);
                Instantiate(healthObject, healthPoint , UnityEngine.Quaternion.identity);
           }
        else if (enemyCharacter != null && !enemyCharacter.CompareTag("EnemyNoShoot"))
            {
                Destroy(enemyCharacter.gameObject);
                Destroy(gameObject);
            }      
  }

}