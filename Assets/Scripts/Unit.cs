using UnityEngine;
[RequireComponent(typeof(Attack))]

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{

    protected Rigidbody rb;
    protected Health health;
    protected Attack attack;

    [SerializeField] private float speed = 10;
    protected float Speed => speed;
    [SerializeField] private string targetTag = "Enemy";
    protected string TargetTag => targetTag;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
        attack = GetComponent<Attack>();
    }

    protected virtual GameObject FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        GameObject closest = null;
        float closestDistance = Mathf.Infinity;


        foreach (GameObject target in targets)
        {

            if (target == null)
            {
                continue;
            }

            Health targetHealth = target.GetComponent<Health>();

            if (targetHealth == null || targetHealth.IsDead)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, target.transform.position);


            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = target;
            }

        }

        return closest;
    }

}
