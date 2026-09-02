using UnityEngine;

public class Health : MonoBehaviour
{
    private static readonly int DieHash = Animator.StringToHash("Die");
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
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
            animator.SetTrigger(DieHash);
            gameObject.layer = LayerMask.NameToLayer("DeadUnit");
        }
    }
    public bool IsDead => currentHealth == 0;

}
