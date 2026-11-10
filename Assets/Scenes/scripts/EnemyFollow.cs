using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float refreshInterval = 0.25f;
    private NavMeshAgent agent;
    private Transform player;
    private float timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
            player = target.transform;
    }
    private void Update()
    {
        if (player == null || !agent.isOnNavMesh) return;

        timer -= Time.deltaTime;
        if (timer > 0f) return;

        timer = refreshInterval;
        agent.SetDestination(player.position);
    }
}
