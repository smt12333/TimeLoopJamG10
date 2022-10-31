using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private string Tag;
    [SerializeField] private GameObject itemprefab;
    [SerializeField] private GameObject[] spawnpoints;
    [SerializeField] private GameObject selectspawnpoint;
    [SerializeField] private GameObject item;
  
    
    
    void Start()
    {
        Randomspawners();
    }

    private void Update()
    {
        
    }
    private void Randomspawners()
    {

        spawnpoints = GameObject.FindGameObjectsWithTag(Tag);

        int rand = Random.Range(0, spawnpoints.Length);

        selectspawnpoint = spawnpoints[rand];

        item = Instantiate(itemprefab, selectspawnpoint.transform.position, selectspawnpoint.transform.localRotation);
    }
}
