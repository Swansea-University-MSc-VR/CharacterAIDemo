﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_Chasing : StateMachineBehaviour
{
    private AI_Controller_State_Machine_Animator _stateMachine;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _stateMachine = animator.gameObject.GetComponent<AI_Controller_State_Machine_Animator>();
        _stateMachine.locomotionAnimation.SetNavMeshDestination(_stateMachine.cafeLocation);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         if (Vector3.Distance( _stateMachine.locomotionAnimation.gameObject.transform.position, _stateMachine.locomotionAnimation.targetTransform.position) < 3f)
        {           
            _stateMachine.locomotionAnimation.SetNavMeshDestination(_stateMachine.locomotionAnimation.gameObject.transform);
            animator.SetBool("isChasing", false);
        }           
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}