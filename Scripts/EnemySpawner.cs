using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public Transform[] spawnPoints;
    public GameObject[] enemyCharacter;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float minTimeBetweenSpawns;
    public float decrease;

    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
         if(Player != null) {
        
            if(timeBtwSpawns <= 0) {
                // int randPos = Random.Range(0, spawnPoints.Length);
                // int randHaz = Random.Range(0, hazards.Length);
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = enemyCharacter[Random.Range(0, enemyCharacter.Length)];
                
            // Instantiate(hazards[random], spawnPoints[randPos].position, Quaternion.identity);
                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);
                if(startTimeBtwSpawns > minTimeBetweenSpawns) {
                    startTimeBtwSpawns -= decrease;
                }

                timeBtwSpawns = startTimeBtwSpawns;
            } else {
                timeBtwSpawns -= Time.deltaTime;
            }
        } else{
            Destroy(gameObject);
        }
        
    }
        
    
}
