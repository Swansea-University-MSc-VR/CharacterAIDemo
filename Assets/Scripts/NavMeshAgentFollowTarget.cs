using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshAgentAnimationSync))]
public class NavMeshAgentFollowTarget : MonoBehaviour
{
    private NavMeshAgentAnimationSync _navMeshAgentAnimationSync;

    public Transform target;

    private void Awake()
    {
        _navMeshAgentAnimationSync = GetComponent<NavMeshAgentAnimationSync>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            _navMeshAgentAnimationSync.SetNavMeshDestination(target.position);
        }
    }
}
