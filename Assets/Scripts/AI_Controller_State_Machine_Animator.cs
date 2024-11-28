using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Controller_State_Machine_Animator : MonoBehaviour
{
    public Animator stateMachineAnimator;
    public NavMeshAgentAnimationSync navMeshAgentAnimationSync;
    public NavMeshAgentRandomLocation navMeshAgentRandomLocation;

    public Transform cafeLocation;
    public Transform homeLocation;

    public Transform moveTarget;

    private void Start()
    {
        navMeshAgentAnimationSync = transform.parent.GetComponent<NavMeshAgentAnimationSync>();
        navMeshAgentRandomLocation = transform.parent.GetComponent<NavMeshAgentRandomLocation>();
    }

    private void OnEnable()
    {
        Newspaper.OnCelebritySpottedAtCafe += Newspaper_onCelebritySpottedAtCafe;   
    }

    private void Newspaper_onCelebritySpottedAtCafe()
    {
        navMeshAgentRandomLocation.StopMoving();
        moveTarget = cafeLocation;
        stateMachineAnimator.SetBool("isChasing", true);
    }

    private void OnDisable()
    {
        Newspaper.OnCelebritySpottedAtCafe -= Newspaper_onCelebritySpottedAtCafe;
    }
}