using UnityEngine;

public class Attack : MonoBehaviour
{
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    [SerializeField] private int attackDamage;
    [SerializeField] private int attackRange;
    [SerializeField] private float attackCooldown;
    private float nextAttackTime;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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

        if (target.TryGetComponent<Health>(out Health targetHealth))
        {
            targetHealth.TakeDamage(attackDamage);
            nextAttackTime = Time.time + attackCooldown;
            animator.SetTrigger(AttackHash);
        }

    }
}
