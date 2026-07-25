using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 10;
    [SerializeField] private string opponentTag = "Enemy";
    private Rigidbody aiRb;
    [SerializeField] private GameObject[] opponents;
    void Start()
    {
        aiRb = GetComponent<Rigidbody>();
        opponents = GameObject.FindGameObjectsWithTag(opponentTag);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        GameObject closestOpponent = FindClosestTarget();

        if (closestOpponent == null)
        {
            return;
        }

        Vector3 direction = (closestOpponent.transform.position - transform.position).normalized;

        Vector3 nextPosition = aiRb.position + direction * speed * Time.fixedDeltaTime;

        aiRb.MovePosition(nextPosition);

    }

    public GameObject FindClosestTarget()
    {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;


        foreach (GameObject opponent in opponents)
        {
            float distance = Vector3.Distance(transform.position, opponent.transform.position);

            if (opponent == null)
            {
                continue;
            }

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = opponent;
            }

        }

        if (closest != null)
        {
            Debug.Log("Closest opponent:" + closest.name);
        }

        return closest;
    }
}
