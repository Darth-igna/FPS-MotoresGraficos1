using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum VictoryMode
    {
        Escape,
        EliminateEnemies
    }

    [SerializeField] private VictoryMode victoryMode;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text enemiesText; // EXTRA: contador en pantalla

    private int remainingEnemies;
    private bool gameEnded;

    private void Start()
    {
        remainingEnemies = FindObjectsByType<Enemy>(
            FindObjectsSortMode.None
        ).Length;

        resultText.gameObject.SetActive(false);
        UpdateEnemiesText();
    }

    public void EnemyDefeated()
    {
        if (gameEnded)
            return;

        remainingEnemies = Mathf.Max(0, remainingEnemies - 1);
        UpdateEnemiesText();

        if (victoryMode == VictoryMode.EliminateEnemies &&
            remainingEnemies == 0)
        {
            FinishGame("VICTORIA");
        }
    }
    public void ReachEscape()
    {
        if (victoryMode == VictoryMode.Escape)
            FinishGame("VICTORIA");
    }

    public void PlayerDefeated()
    {
        FinishGame("DERROTA");
    }

    private void UpdateEnemiesText() // EXTRA
    {
        if (enemiesText != null)
            enemiesText.text = "Enemigos: " + remainingEnemies;
    }

    private void FinishGame(string message)
    {
        if (gameEnded)
            return;

        gameEnded = true;
        resultText.text = message;
        resultText.gameObject.SetActive(true);
        Time.timeScale = 0f; 
    }
}
