using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float hitDistance = 0.1f;
    private GameObject target;
    private Attack sourceAttack;

    void Start()
    {

    }

    void Update()
    {
        ArrowFlight();
    }

    public void Initialize(GameObject newTarget, Attack newSourceAttack)
    {
        target = newTarget;
        sourceAttack = newSourceAttack;
    }

    public void ArrowFlight()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= hitDistance)
        {
            sourceAttack.ApplyDamage(target);
            Destroy(gameObject);
            return;
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
