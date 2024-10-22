using UnityEngine;

public class PaperGenerator : MonoBehaviour
{
    public GameObject paperPrefab;  // The paper prefab to instantiate
    public GameObject ceiling;  // Reference to the ceiling object
    public float spawnInterval = 2f;  // Time interval between paper spawns
    private float ceilingWidth;

    void Start()
    {
        // Calculate the width of the ceiling using its collider bounds
        ceilingWidth = ceiling.GetComponent<BoxCollider2D>().bounds.size.x;

        // Start generating paper at regular intervals
        InvokeRepeating("GeneratePaper", 0f, spawnInterval);
    }

    void GeneratePaper()
    {
        // Get the ceiling's position
        Vector3 ceilingPosition = ceiling.transform.position;

        // Randomly choose a position along the width of the ceiling
        float randomX = Random.Range(ceilingPosition.x - ceilingWidth / 2, ceilingPosition.x + ceilingWidth / 2);

        // Set the spawn position just below the ceiling
        Vector3 spawnPosition = new Vector3(randomX, ceilingPosition.y, ceilingPosition.z);

        // Instantiate the paper prefab at the random position
        Instantiate(paperPrefab, spawnPosition, Quaternion.identity);
    }
}
