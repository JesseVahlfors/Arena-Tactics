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

        healTarget = null;
    }

    protected override bool ShouldFindNewTarget()
    {
        if (base.ShouldFindNewTarget())
        {
            return true;
        }

        if (Time.time < nextPriorityCheckTime)
        {
            return false;
        }

        nextPriorityCheckTime = Time.time + priorityCheckInterval;

        GameObject injuredAlly = FindLowestHealthTarget("Player", true);

        if (!isHealing)
        {
            if (injuredAlly != null)
            {
                return true;
            }


            return false;
        }

        if (isHealing &&
    CurrentTarget.TryGetComponent<Health>(out Health targetHealth) &&
    !targetHealth.IsInjured)
        {
            return true;
        }

        return false;
    }
}
