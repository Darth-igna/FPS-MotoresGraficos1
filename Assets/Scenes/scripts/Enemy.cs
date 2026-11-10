using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float deathDelay = 2.5f;

    private NavMeshAgent agent;
    private EnemyFollow follow;
    private GameController gameController;

    public bool IsDead { get; private set; }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        follow = GetComponent<EnemyFollow>();
        gameController = FindFirstObjectByType<GameController>();
    }
    public void Die()
    {
        if (IsDead)
            return;

        IsDead = true;

        if (follow != null)
            follow.enabled = false;

        if (agent != null && agent.enabled && agent.isOnNavMesh)
        {
            agent.isStopped = true;
            agent.ResetPath();
        }

        if (animator != null)
            animator.SetTrigger("Die");

        if (gameController != null)
            gameController.EnemyDefeated();

        Destroy(gameObject, deathDelay);
    }
}
