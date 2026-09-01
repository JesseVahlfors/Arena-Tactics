using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Health))]
public class AIController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private string opponentTag = "Enemy";
    private Rigidbody aiRb;
    private Health health;
    private Attack attack;
    private void Awake()
    {
        aiRb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
        attack = GetComponent<Attack>();
    }

    void FixedUpdate()
    {

        if (health.IsDead)
        {
            return;
        }
        GameObject closestOpponent = FindClosestTarget();

        if (closestOpponent == null)
        {
            return;
        }

        bool canAttack = attack.CanAttack(closestOpponent);

        if (canAttack)
        {
            attack.AttackTarget(closestOpponent);
            return;
        }


        Vector3 direction = (closestOpponent.transform.position - transform.position).normalized;

        Vector3 nextPosition = aiRb.position + direction * speed * Time.fixedDeltaTime;
        Quaternion rotation = Quaternion.LookRotation(direction);
        aiRb.MovePosition(nextPosition);
        aiRb.MoveRotation(rotation);

    }

    /* private void OnCollisionEnter(Collision collision)
    {
        Health otherHealth = collision.gameObject.GetComponent<Health>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (otherHealth != null)
            {
                otherHealth.TakeDamage(100);
            }
        }
    } */

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

            Health opponentHealth = opponent.GetComponent<Health>();

            if (opponentHealth == null || opponentHealth.IsDead)
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
