using UnityEngine;

public class Ranger : Unit
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;


    public void SpawnArrow()
    {

        if (health.IsDead)
        {
            return;
        }

        GameObject target = attack.CurrentAttackTarget;

        if (target == null)
        {
            return;
        }

        if (!target.TryGetComponent<Health>(out Health targetHealth) || targetHealth.IsDead)
        {
            return;
        }

        GameObject spawnedArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);

        if (!spawnedArrow.TryGetComponent<Arrow>(out Arrow arrow))
        {
            Debug.LogWarning("No arrow script on arrow prefab");
            Destroy(spawnedArrow);
            return;
        }

        arrow.Initialize(target, attack.AttackDamage);
    }
}
