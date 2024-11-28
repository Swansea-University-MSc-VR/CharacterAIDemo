using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Creature : MonoBehaviour
{
    public enum CreatureState
    {
        Idle = 0,
        Waiting = 1,
        Moving = 2,
        Resetting = 3,
        GettingKnockedBack = 4,
        Dashing = 5,
        Meleeing = 6,
        Projectiling = 7,
        AreaOfEffecting = 8,
        Evading = 9,
        Walling = 10,
        Shielding = 11,
        Buffing = 12,
        Debuffing = 13,
        TransitionToMove = 14,
        ChargingSuper = 15,
        Celebrating = 16,
        Dead = 17,
        InVR,
    }


    #region variables

    public CreatureState state;



    protected CreatureState _creatureState;
    public CreatureState creatureState
    {
        get
        {
            return _creatureState;
        }
        set
        {
            if (CanTransitionState(value, _creatureState))
            {
                ExitState(_creatureState);
                _creatureState = value;
                EnterState(_creatureState);
            }
        }
    } 



    #endregion

  
    void EnterState(CreatureState stateEntered)
    {
        switch (stateEntered)
        {
            case CreatureState.Idle:
                //  _creatureAnimator.StartIdle();
                break;

            case CreatureState.Waiting:
                break;

            case CreatureState.Moving:
                break;

            case CreatureState.Resetting:
                //_creatureAnimator.StartIdle();
                break;

            case CreatureState.Celebrating:
                //   _creatureAnimator.StartVictory();
                break;

            case CreatureState.GettingKnockedBack:
                break;

            case CreatureState.Dashing:
                break;

            case CreatureState.Evading:

                break;

            case CreatureState.TransitionToMove:
                creatureState = CreatureState.Moving;
                break;

            case CreatureState.Meleeing:

                break;

            case CreatureState.Projectiling:

                break;

            case CreatureState.AreaOfEffecting:
                //_creatureAnimator.StartAOE();
                break;

            case CreatureState.Walling:
                break;

            case CreatureState.Shielding:
                break;

            case CreatureState.Buffing:
                break;

            case CreatureState.Debuffing:
                break;

            case CreatureState.ChargingSuper:
                break;

            case CreatureState.Dead:
                break;
        }
    }

    void ExitState(CreatureState stateExited)
    {
        switch (stateExited)
        {
            case CreatureState.Idle:
                break;

            case CreatureState.Moving:
                break;

            case CreatureState.Resetting:
                break;

            case CreatureState.Celebrating:
                break;

            case CreatureState.Waiting:
                break;

            case CreatureState.GettingKnockedBack:
                break;

            case CreatureState.Dashing:
                break;

            case CreatureState.Evading:
                break;

            case CreatureState.TransitionToMove:
                break;

            case CreatureState.Meleeing:
                break;

            case CreatureState.Projectiling:
                break;

            case CreatureState.AreaOfEffecting:
                break;

            case CreatureState.Walling:
                break;

            case CreatureState.Shielding:
                break;

            case CreatureState.Buffing:
                break;

            case CreatureState.ChargingSuper:

            case CreatureState.Dead:
                break;
        }
    }

    # region State Coroutines
    protected virtual IEnumerator Idle()
    {
        //_navAgent.enabled = true;
        //_navAgent.Stop();
        //_navAgent.ResetPath();  


        //    if (CheckForDeath())
        //    {
        //        _diedOnTheSpot = true;
        //        creatureState = CreatureState.Dead;
        //    }

        yield return null;

    }

    protected IEnumerator Waiting()
    {
        yield return null;
    }

    protected IEnumerator Moving()
    {
        //if (CheckForDeath())
        //{
        //    _diedOnTheSpot = true;
        //    creatureState = CreatureState.Dead;
        //}
        //else
        //{
        //    creatureState = CreatureState.Idle;
        //}

        yield return null;
    }

    protected IEnumerator Resetting()
    {

        creatureState = CreatureState.Waiting;
        yield return null;
    }

    protected IEnumerator Dashing()
    {

        yield return null;
    }

    protected IEnumerator WaitingToCelebrate()
    {
        while (_creatureState != CreatureState.Idle)
        {
            yield return null;
        }

        creatureState = Creature.CreatureState.Celebrating;
    }

    protected IEnumerator Celebrating()
    {

        yield return null;

    }

    protected IEnumerator Evading()
    {

        yield return null;
    }

    protected IEnumerator Meleeing()
    {

        yield return null;
    }

    protected virtual IEnumerator Projectiling()
    {
        yield return null;
    }

    protected virtual IEnumerator AreaOfEffecting()
    {
        yield return null;
    }

    protected virtual IEnumerator Walling()
    {
        yield return null;
    }

    protected IEnumerator Shielding()
    {

        yield return null;
    }

    protected IEnumerator Buffing()
    {


        yield return null;
    }

    protected IEnumerator Debuffing()
    {


        yield return null;
    }

    protected virtual IEnumerator GettingKnockedBack()
    {

        yield return null;
    }

    protected IEnumerator Dead()
    {

        while (true)
        {
            yield return null;
        }
    }

    protected IEnumerator ChargingSuper()
    {

        yield return null;
    }
    #endregion       

    protected virtual bool CanTransitionState(CreatureState newState, CreatureState oldState)
    {
        if (newState == CreatureState.Idle)
        {
            if (oldState != CreatureState.Dead &&
                oldState != CreatureState.Celebrating)
            {
                return true;
            }
        }

        if (newState == CreatureState.Waiting)
        {
            return true;
        }

        if (newState == CreatureState.Celebrating)
        {
            return true;
        }

        if (newState == CreatureState.Moving)
        {
            if (oldState != CreatureState.Dashing &&
                oldState != CreatureState.Meleeing &&
                oldState != CreatureState.Projectiling &&
                oldState != CreatureState.GettingKnockedBack &&
                oldState != CreatureState.Evading &&
                oldState != CreatureState.Dead)
            {
                return true;
            }
        }

        if (newState == CreatureState.Dashing)
        {
            if (oldState != CreatureState.GettingKnockedBack &&
                oldState != CreatureState.Dead)
            {
                return true;
            }
        }

        if (newState == CreatureState.Evading)
        {
            return true;
        }

        if (newState == CreatureState.Meleeing)
        {
            if (oldState == CreatureState.Moving ||
                oldState == CreatureState.Idle ||
                oldState == CreatureState.Waiting ||
                oldState == CreatureState.Celebrating)
            {
                return true;
            }
            else
               if (Debug.isDebugBuild) { Debug.Log("cannot switch creature state"); }
        }

        if (newState == CreatureState.Projectiling)
        {
            if (oldState == CreatureState.Moving ||
                   oldState == CreatureState.Idle ||
                   oldState == CreatureState.Waiting)
            {
                return true;
            }
            else
                if (Debug.isDebugBuild) { Debug.Log("cannot switch creature state"); }
        }

        if (newState == CreatureState.TransitionToMove)
        {
            return true;
        }

        if (newState == CreatureState.GettingKnockedBack)
        {
            if (oldState != CreatureState.Evading &&
                 oldState != CreatureState.Dead)
            {
                return true;
            }
        }


        if (newState == CreatureState.Dead)
        {
            return true;
        }

        if (newState == CreatureState.AreaOfEffecting)
        {
            if (oldState == CreatureState.Moving ||
                   oldState == CreatureState.Idle ||
                   oldState == CreatureState.Waiting)
            {
                return true;
            }
            else
                if (Debug.isDebugBuild) { Debug.Log("cannot switch creature state"); }
        }

        if (newState == CreatureState.Walling)
        {
            if (oldState == CreatureState.Moving ||
                 oldState == CreatureState.Idle ||
                 oldState == CreatureState.Waiting)
            {
                return true;
            }
            else
                if (Debug.isDebugBuild) { Debug.Log("cannot switch creature state"); }
        }

        if (newState == CreatureState.Shielding)
        {
            if (oldState == CreatureState.Moving ||
                 oldState == CreatureState.Idle ||
                 oldState == CreatureState.Waiting)
            {
                return true;
            }
            else
                if (Debug.isDebugBuild) { Debug.Log("cannot switch creature state"); }
        }

        if (newState == CreatureState.Buffing)
        {
            if (oldState == CreatureState.Moving ||
                oldState == CreatureState.Idle ||
                oldState == CreatureState.Waiting)
            {
                return true;
            }
            else
                if (Debug.isDebugBuild) { Debug.Log("cannot switch creature state"); }
        }

        if (newState == CreatureState.Debuffing)
        {
            if (oldState == CreatureState.Moving ||
                 oldState == CreatureState.Idle ||
                 oldState == CreatureState.Waiting)
            {
                return true;
            }
            else
                if (Debug.isDebugBuild) { Debug.Log("cannot switch creature state"); }
        }

        if (newState == CreatureState.Resetting)
        {
            return true;
        }

        if (newState == CreatureState.ChargingSuper)
        {
            return true;
        }

        return false;
    }


}