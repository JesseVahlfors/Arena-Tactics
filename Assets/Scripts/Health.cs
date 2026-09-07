using UnityEngine;

public class Health : MonoBehaviour
{
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int DieHash = Animator.StringToHash("Die");
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    public bool IsInjured => currentHealth < maxHealth;
    public bool IsDead => currentHealth == 0;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead)
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

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

    }

}
