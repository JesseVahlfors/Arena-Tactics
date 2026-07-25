using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {

        for (int i = 0; i < 5; i++)
        {
            int posX = Random.Range(-23, 23);
            int posZ = Random.Range(0, 23);

            Instantiate(enemyPrefab, new Vector3(posX, 0.5f, posZ), transform.rotation);
        }
    }
}
