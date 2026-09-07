using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Healer : Unit
{
    private static readonly int HealActionHash = Animator.StringToHash("HealAction");
    [SerializeField] private int healAmount = 75;
    [SerializeField] private float healCooldown = 2;
    [SerializeField] private float priorityCheckInterval = 0.25f;
    private float nextPriorityCheckTime;
    private GameObject healTarget;
    private bool isHealing;
    private float nextHealTime;
    private Animator animator;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    protected override GameObject FindTarget()
    {
        GameObject target = FindLowestHealthTarget("Player", injuredOnly: true);

        if (target != null)
        {
            isHealing = true;
            return target;
        }
        else
        {
            isHealing = false;
            return FindLowestHealthTarget("Enemy", injuredOnly: false);
        }
    }

    private GameObject FindLowestHealthTarget(string targetTag, bool injuredOnly)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        GameObject lowestHealthTarget = null;
        float lowestHealthPercentage = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            if (target == null)
            {
                continue;
            }

            if (!target.TryGetComponent<Health>(out Health targetHealth) || targetHealth.IsDead || (injuredOnly && !targetHealth.IsInjured))
            {
                continue;
            }

            if (targetHealth.HealthPercentage < lowestHealthPercentage)
            {
                lowestHealthPercentage = targetHealth.HealthPercentage;
                lowestHealthTarget = target;
            }
        }

        return lowestHealthTarget;
    }

    // POLYMORPHISM: Healer replaces the default combat action with healing or fallback attacking.
    protected override void PerformCombatAction()
    {
        if (isHealing)
        {
            if (CanHeal())
            {
                BeginHeal(CurrentTarget);
            }
        }
        else
        {
            if (attack.CanAttack())
            {
                attack.AttackTarget(CurrentTarget);
            }
        }
    }

    public void BeginHeal(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        healTarget = target;
        nextHealTime = Time.time + healCooldown;
        animator.SetTrigger(HealActionHash);

    }

    public bool CanHeal() => Time.time > nextHealTime;
    public void OnHealHit()
    {
        if (healTarget == null)
        {
            return;
        }

        if (healTarget.TryGetComponent<Health>(out Health targetHealth))
        {
            targetHealth.Heal(healAmount);
        }
    }

    public void OnHealEnd()
    {
        healTarget = null;
    }

    protected override bool ShouldFindNewTarget()
    {
        if (base.ShouldFindNewTarget())
        {
            return true;
        }

        if (healTarget != null)
        {
            return false;
        }

        if (Time.time < nextPriorityCheckTime)
        {
            return false;
        }

        nextPriorityCheckTime = Time.time + priorityCheckInterval;

        GameObject injuredAlly = FindLowestHealthTarget("Player", true);

        if (!isHealing)
        {
            return injuredAlly != null;
        }

        if (isHealing)
        {
            if (CurrentTarget.TryGetComponent<Health>(out Health currentHealth))
            {
                if (!currentHealth.IsInjured)
                {
                    return true;
                }

                if (injuredAlly != null &&
                    injuredAlly.TryGetComponent<Health>(out Health lowestHealth) &&
                    lowestHealth.HealthPercentage < currentHealth.HealthPercentage)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
