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
    private GameObject currentTarget;
    protected GameObject CurrentTarget => currentTarget;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
        attack = GetComponent<Attack>();
    }


    void FixedUpdate()
    {
        if (health.IsDead)
        {
            return;
        }

        if (!IsTargetValid())
        {
            SetTarget(FindTarget());
        }

        if (CurrentTarget == null)
        {
            return;
        }

        Vector3 direction = GetDirectionToTarget();
        FaceTarget(direction);

        if (attack.InRange(CurrentTarget))
        {
            PerformCombatAction();
        }
        else
        {
            MoveIntoRange(direction);
        }

    }

    protected virtual GameObject FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag);

        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;


        foreach (GameObject target in targets)
        {

            Health targetHealth = target.GetComponent<Health>();

            if (targetHealth == null || targetHealth.IsDead)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, target.transform.position);


            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
            }

        }

        return closestTarget;
    }

    protected void SetTarget(GameObject target)
    {
        currentTarget = target;
    }

    protected Vector3 GetDirectionToTarget()
    {
        Vector3 direction = CurrentTarget.transform.position - transform.position;
        direction.y = 0f;

        return direction;
    }

    protected void FaceTarget(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.001f)
        {
            direction = direction.normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(rotation);
        }
    }

    protected void MoveIntoRange(Vector3 direction)
    {
        direction = direction.normalized;

        Vector3 nextPosition = rb.position + Speed * Time.fixedDeltaTime * direction;
        rb.MovePosition(nextPosition);
    }

    protected virtual void PerformCombatAction()
    {
        if (attack.CanAttack())
        {
            attack.AttackTarget(CurrentTarget);
        }
    }

    protected bool IsTargetValid()
    {
        if (CurrentTarget == null)
        {
            return false;
        }

        if (!CurrentTarget.TryGetComponent<Health>(out Health targetHealth))
        {
            return false;
        }

        if (targetHealth.IsDead)
        {
            return false;
        }

        return true;
    }

}
