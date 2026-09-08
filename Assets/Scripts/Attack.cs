using UnityEngine;
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Unit))]
public class Attack : MonoBehaviour
{
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    [SerializeField] private int attackDamage;
    [SerializeField] private int attackRange;
    [SerializeField] private float attackCooldown;
    private GameObject attackTarget;
    private float nextAttackTime;
    private Animator animator;
    private Health health;
    private Unit unit;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        unit = GetComponent<Unit>();
    }

    public bool CanAttack()
    {
        if (Time.time > nextAttackTime)
        {
            return true;
        }

        return false;
    }

    public bool InRange(GameObject target)
    {

        if (target == null)
        {
            return false;
        }

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= attackRange)
        {
            return true;
        }

        return false;
    }

    public void AttackTarget(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        attackTarget = target;
        BeginAttack(target);
    }

    public void BeginAttack(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        nextAttackTime = Time.time + attackCooldown;
        animator.SetTrigger(AttackHash);

    }

    public void OnAttackHit()
    {
        if (health.IsDead)
        {
            return;
        }

        if (attackTarget == null)
        {
            return;
        }

        ApplyDamage(attackTarget);
    }

    public void OnAttackEnd()
    {
        attackTarget = null;

        if (unit != null)
        {
            unit.EndAction();
        }
    }

    public void ApplyDamage(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        if (target.TryGetComponent<Health>(out Health targetHealth))
        {
            targetHealth.TakeDamage(attackDamage);
        }
    }

    public void CancelAttack()
    {
        attackTarget = null;
        animator.ResetTrigger(AttackHash);
    }
}
