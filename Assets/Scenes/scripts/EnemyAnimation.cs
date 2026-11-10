using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Enemy enemy;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (enemy == null)
            enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (animator == null || enemy == null || enemy.IsDead)
            return;

        bool moving = agent.enabled &&
                      agent.isOnNavMesh &&
                      agent.velocity.sqrMagnitude > 0.04f;

        animator.SetBool("IsMoving", moving);
    }
}
