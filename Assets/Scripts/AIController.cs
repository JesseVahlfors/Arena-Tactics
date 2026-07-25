using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AIController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private string opponentTag = "Enemy";
    private Rigidbody aiRb;
    private void Awake()
    {
        aiRb = GetComponent<Rigidbody>();
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

    private void OnCollisionEnter(Collision collision)
    {
        // Temporary Lab 4 combat rule: only objects tagged Enemy are destroyed.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    public GameObject FindClosestTarget()
    {
        GameObject[] opponents = GameObject.FindGameObjectsWithTag(opponentTag);

        GameObject closest = null;
        float closestDistance = Mathf.Infinity;


        foreach (GameObject opponent in opponents)
        {
            if (opponent == null)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, opponent.transform.position);


            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = opponent;
            }

        }

        return closest;
    }
}
