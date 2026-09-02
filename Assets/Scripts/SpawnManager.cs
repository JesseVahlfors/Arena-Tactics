using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject raiderPrefab;
    [Header("Positions")]
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    private void Start()
    {
        SpawnEnemy(raiderPrefab, spawnPoint1);
        SpawnEnemy(raiderPrefab, spawnPoint2);
    }

    private void SpawnEnemy(GameObject prefab, Transform spawnPoint)
    {
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
