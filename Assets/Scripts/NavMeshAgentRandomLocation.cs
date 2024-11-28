using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshAgentAnimationSync))]
public class NavMeshAgentRandomLocation : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private NavMeshTriangulation _triangulation;
    private NavMeshAgentAnimationSync _navMeshAgentAnimationSync;

    [Range(0f, 3f)]
    public float waitDelay;

    [Range(0f, 100f)]
    public float maxRange;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _triangulation = NavMesh.CalculateTriangulation();
        _navMeshAgentAnimationSync = GetComponent<NavMeshAgentAnimationSync>();
    }

    private void Start()
    {
        StartCoroutine(MoveToRandomPoint());
    }

    private IEnumerator MoveToRandomPoint()
    {
        _navMeshAgent.enabled = true;
        _navMeshAgent.isStopped = false;
        WaitForSeconds wait = new WaitForSeconds(waitDelay);
        while (true)
        {
            // Generate a random point within the specified range
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * maxRange;
            //randomPoint.y = startingPosition.y; // Keep the agent on the same Y level if needed

            // Check if the random point is on the NavMesh
            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, maxRange, NavMesh.AllAreas))
            {
                _navMeshAgent.SetDestination(hit.position);

                yield return null;
                yield return new WaitUntil(() => _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance);
                yield return wait;
            }
            else
            {
                // If the point is not valid, try again in the next loop iteration
                yield return null;
            }
        }
    }
}