using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    [SerializeField] private int attackRange;
    [SerializeField] private int attackCooldown;

    public bool CanAttack(GameObject target)
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
        }
    }
}
