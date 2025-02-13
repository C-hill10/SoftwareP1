using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] hazards;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float minTimeBetweenSpawns;
    public float decrease;

    public GameObject Player;


  // Update is called once per frame
    void Update()
    {
        if(Player != null) {
        
            if(timeBtwSpawns <= 0) {
                // int randPos = Random.Range(0, spawnPoints.Length);
                // int randHaz = Random.Range(0, hazards.Length);
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];
                
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
