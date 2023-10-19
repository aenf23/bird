using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnDelay = 1.75f;
    public float minHeight = -2f;
    public float maxHeight = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnDelay);
    }

    private void SpawnPipe()
    {
        float randomHeight = Random.Range(minHeight, maxHeight);
        Vector2 spawnPosition = new Vector2(transform.position.x, randomHeight);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}