using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public bool battleStarted;
    public bool battleEnded;
    [SerializeField] private GameObject battleEndPanel;
    [SerializeField] private TMP_Text resultText;

    void Update()
    {
        if (!battleStarted)
        {
            return;
        }

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
        resultText.text = "Victory!";
        battleEndPanel.SetActive(true);
    }

    public void Defeat()
    {
        battleEnded = true;
        resultText.text = "Defeat!";
        battleEndPanel.SetActive(true);
    }

    public void RestartGame()
    {
        battleStarted = false;
        SceneManager.LoadScene("MainScene");
        battleEndPanel.SetActive(false);
    }

    public void BattleStart()
    {
        battleStarted = true;
    }
}
