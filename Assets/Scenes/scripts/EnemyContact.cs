using UnityEngine;

public class EnemyContact : MonoBehaviour
{
    private Enemy enemy;
    private GameController gameController;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        gameController = FindFirstObjectByType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemy == null || enemy.IsDead || gameController == null)
            return;

        if (other.CompareTag("Player"))
            gameController.PlayerDefeated();
    }
}
