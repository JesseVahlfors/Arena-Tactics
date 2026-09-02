using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public bool battleEnded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (battleEnded)
        {
            return;
        }

        if (AreAllUnitsDead("Enemy"))
        {
            Victory();
        }
        else if (AreAllUnitsDead("Player"))
        {
            Defeat();
        }
    }

    public bool AreAllUnitsDead(string tag)
    {
        GameObject[] combatants = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject combatant in combatants)
        {
            if (combatant == null)
            {
                continue;
            }

            if (combatant.TryGetComponent<Health>(out Health combatantHealth))
            {
                if (!combatantHealth.IsDead)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void Victory()
    {
        battleEnded = true;
        Debug.Log("Victory!");
    }

    public void Defeat()
    {
        battleEnded = true;
        Debug.Log("Defeat :(");
    }
}
