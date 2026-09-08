using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int DieHash = Animator.StringToHash("Die");
    [SerializeField] private int maxHealth = 100;
    // ENCAPSULATION: Health can only be changed through TakeDamage() and Heal().
    [SerializeField] private int currentHealth;
    public bool IsInjured => currentHealth < maxHealth;
    public bool IsDead => currentHealth == 0;
    public float HealthPercentage => (float)currentHealth / maxHealth;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        maxHealth = Mathf.Max(1, maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead)
        {
            return;
        }

        if (amount <= 0)
        {
            return;
        }

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (IsDead)
        {
            animator.ResetTrigger(AttackHash);
            animator.SetTrigger(DieHash);
            gameObject.layer = LayerMask.NameToLayer("DeadUnit");
        }
    }

    public void Heal(int amount)
    {
        if (IsDead)
        {
            return;
        }

        if (amount <= 0)
        {
            return;
        }

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    }

}
