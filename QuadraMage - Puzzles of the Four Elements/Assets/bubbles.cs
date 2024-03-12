using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime = 5f;
    public GameObject bubblesPrefab;
    public float spawnInterval = 3f; // Adjust as needed
    private float nextSpawnTime = 0f;
    private float elapsedTime = 0f;
    GameObject bubbleInstance;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(12,13);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBubble();
            nextSpawnTime = Time.time + spawnInterval;
        }
        
    }

    void SpawnBubble()
    {
        bubbleInstance = Instantiate(bubblesPrefab, transform.position, Quaternion.identity);
        Destroy(bubbleInstance, 2);
    }

    
}
