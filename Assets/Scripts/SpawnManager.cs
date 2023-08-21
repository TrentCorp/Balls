using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //delcaring enemy
    public GameObject enemyPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    public GameObject goalkeeperPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiates on scene start (enemyPrefab linked from inspector inpout, where using result from variable below, where it's oriented)
        SpawnEnemyWave(1);
        //Instantiates a powerup object
        SpawnPowerup();
        Instantiate(goalkeeperPrefab, GenerateSpawnPosition(), goalkeeperPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {   
        //search for and count number of enemy script attached objects exist. Creates an array but using .Length to get int 
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //once enemies are defeated increment wave number and increase number of enemies spawned
        if (enemyCount == 0)
        {
            waveNumber++;
            if (waveNumber % 3 == 0)
            {
                SpawnEnemyWave(waveNumber-1);
                SpawnGoalie();
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
           
            // as well as enemies spawned also spawn a power up with the new wave borrowing the generatespawnposition
            SpawnPowerup();
        }
    } 

    //returns a Vector3
    private Vector3 GenerateSpawnPosition()
    {
        //random spawn position aling X axis
        float spawnPosX = Random.Range(-9, 9);
        //random spawn position aling Z axis
        float spawnPosZ = Random.Range(-9, 9);
        //tidying the above ranges into a single variable
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    //for loop sending 3 waves of enemies from Start()
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    //Instantiates a powerup object using the above GenerateSpawnPosition
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnGoalie()
    {
        Instantiate(goalkeeperPrefab, GenerateSpawnPosition(), goalkeeperPrefab.transform.rotation);
    }
}
