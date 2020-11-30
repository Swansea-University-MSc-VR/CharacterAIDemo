using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Controller_State_Machine_Animator : MonoBehaviour
{
    public LocomotionAnimation locomotionAnimation;
    public Animator stateMachineAnimator;

    public Transform cafeLocation;
    public Transform homeLocation;

    public Transform moveTarget;

    private void OnEnable()
    {
        Newspaper.onCelebritySpottedAtCafe += Newspaper_onCelebritySpottedAtCafe;
    }

    private void Newspaper_onCelebritySpottedAtCafe()
    {
        moveTarget = cafeLocation;
        stateMachineAnimator.SetBool("isChasing", true);
    }

    private void OnDisable()
    {
        Newspaper.onCelebritySpottedAtCafe -= Newspaper_onCelebritySpottedAtCafe;
    }
}