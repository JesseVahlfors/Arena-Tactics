using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnAmount = 5;

    [Header("Spawn Area")]
    [SerializeField] private float spawnHeight = 0.5f;
    [SerializeField] private float minSpawnX = -23f;
    [SerializeField] private float maxSpawnX = 23f;
    [SerializeField] private float minSpawnZ = 0f;
    [SerializeField] private float maxSpawnZ = 23f;

    [Header("Spawn Timing")]
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float initialSpawnDelay = 1f;

    [Header("Overlap Check")]
    [SerializeField] private float spawnCheckRadius = 0.75f;
    [SerializeField] private int maxSpawnAttempts = 20;
    [SerializeField] private LayerMask characterLayer;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyWave), initialSpawnDelay, spawnInterval);
    }

    private void SpawnEnemyWave()
    {
        for (int spawn = 0; spawn < spawnAmount; spawn++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {

        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            float randomX = Random.Range(minSpawnX, maxSpawnX);
            float randomZ = Random.Range(minSpawnZ, maxSpawnZ);

            Vector3 spawnPosition = new(randomX, spawnHeight, randomZ);

            // Only character-layer colliders should block this spawn position.
            bool positionBlocked = Physics.CheckSphere(spawnPosition, spawnCheckRadius, characterLayer);

            if (!positionBlocked)
            {
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                return;
            }
        }
        Debug.LogWarning($"Could not find a free spawn position after {maxSpawnAttempts} attempts.");
    }
}
