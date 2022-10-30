using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] spawnobjects;

    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i < spawnpoints.Length ; i++)
        {
           // Instantiate(spawnobjects[Random.Range(0, spawnobjects.Length)], spawnpoints[i]);
        }

        for (int i = 0; i < spawnpoints.Length; i++)
        {
            int randEnemy = Random.Range(0, spawnobjects.Length);
            int randSpawnPoint = Random.Range(0, spawnpoints.Length);

            Instantiate(spawnobjects[0], spawnpoints[randSpawnPoint].position, transform.rotation);
        } 
        
       // Instantiate(spawnobjects[Random.Range(0, spawnobjects.Length)], spawnpoints[Random.Range(0, spawnpoints.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }
    

}