using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshAgentAnimationSync))]

public class NavMeshAgentMousClickSetDestination : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgentAnimationSync _navMeshAgentAnimationSync;

    private void Awake()
    {
        _navMeshAgentAnimationSync = GetComponent<NavMeshAgentAnimationSync>();
    }
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Application.isFocused && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
            {
                _navMeshAgentAnimationSync.CurrentDestinaton = hit.point;
            }
        }
    }
}
