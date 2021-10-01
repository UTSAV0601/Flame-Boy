using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // variable to store all the spawnpoint we created in unity and store transform component attach to them
    public Transform[] spawnPoints;

    //store allthe hazard in our game.
    public GameObject[] hazards;

    //variable to store the time between each spawns
    private float timeBtwSpawns;

    //variable to reset the time between spawns variable 
    public float startTimeBtwSpawns;

    //variables to be used to increase the difficulty of game
    public float mintimeBtwSpawns;
    public float decrease;

    public GameObject player;

    void Update()
    {
        if (player != null)
        {

            if (timeBtwSpawns <= 0)
            {

                //randomly choose spawn point from the spawnPoints array 
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                //randomly choose hazards from the hazard array
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

                //spawn random hazard at random spawn points. we are using Instantiate() where bracket contain 3 parameters.
                // (what do we spawn, where do we want to spawn, rotation in which we want to spawn   )
                Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

                // to check if the game is still easier than max difficulty
                if (startTimeBtwSpawns > mintimeBtwSpawns)
                {
                    startTimeBtwSpawns -= decrease;
                }

                //to resetthe timeBtwSpawn variable because after if statement its value will still be 0 and hazards would continue to spawn
                timeBtwSpawns = startTimeBtwSpawns;


            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
