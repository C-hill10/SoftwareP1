using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  private void OnTriggerEnter2D(Collider2D other) {
        
        Player playerCharacter = other.GetComponent<Player>();

        if (playerCharacter != null) {            

            if (playerCharacter.health < playerCharacter.maxHealth) {
                playerCharacter.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
    
}

