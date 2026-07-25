using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minSpawnX = -23f;
    [SerializeField] private float maxSpawnX = 23f;
    [SerializeField] private float minSpawnZ = 0f;
    [SerializeField] private float maxSpawnZ = 23f;

    [SerializeField] private float spawnCheckRadius = 0.75f;
    [SerializeField] private int maxSpawnAttempts = 20;
    [SerializeField] private int spawnAmount = 5;
    [SerializeField] private LayerMask characterLayer;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyWave), 1f, 5f);
    }

    void SpawnEnemyWave()
    {
        for (int spawn = 0; spawn < spawnAmount; spawn++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {

        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            float randomX = Random.Range(minSpawnX, maxSpawnX);
            float randomZ = Random.Range(minSpawnZ, maxSpawnZ);

            Vector3 spawnPosition = new(randomX, 0.5f, randomZ);

            //Check the spawnposition for an existing character and try again if found
            bool positionBlocked = Physics.CheckSphere(spawnPosition, spawnCheckRadius, characterLayer);

            if (!positionBlocked)
            {
                Instantiate(enemyPrefab, spawnPosition, transform.rotation);
                return;
            }
        }
    }
}
