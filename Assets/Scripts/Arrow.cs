using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float hitDistance = 0.1f;
    private GameObject target;
    private int damage;

    void Update()
    {
        ArrowFlight();
    }

    public void Initialize(GameObject newTarget, int damage)
    {
        target = newTarget;
        this.damage = damage;
    }

    private void ArrowFlight()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetPosition = target.transform.position + Vector3.up * 1.2f;

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance <= hitDistance)
        {
            if (target.TryGetComponent<Health>(out Health targetHealth))
            {
                targetHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
            return;
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
