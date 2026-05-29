
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    public GameObject cloudPrefab;// Prefab for the cloud to be spawned
    public float spawnInterval = 2f;// Time interval between cloud spawns
    public Transform[] spawnPoints;// Array of spwan poitns for clouds to spwan from
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Start()
    {
        // Start spwaning clouds invoke repeating method to spwan clouds at regular intervals;
        InvokeRepeating("spawnClouds", 0f, spawnInterval);
    }

    // Update is called once per frame
    private void spawnClouds()

    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spwan points available for cloud spawning!");
            return;// No spwan points available
        
            {
        
            }

        }
    }
}
