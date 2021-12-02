using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class SurgeChangeState : MonoBehaviour
{
    public StateMachine stateMachine;

    public string targetState;


    private void OnEnable()
    {
        stateMachine.ChangeState(targetState);

       // stateMachine.Next();
    }

 

}
