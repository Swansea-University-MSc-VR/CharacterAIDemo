using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewspaperInputController : MonoBehaviour
{
    public InputActionReference celebSpottedVRcontroller;
    public InputActionReference celebSpottedKeyboard;
    public Newspaper newspaper;

    private void OnEnable()
    {
        celebSpottedVRcontroller.action.performed += Action_performed;
        celebSpottedKeyboard.action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Action performed, sending tip to newspaper");
        newspaper.ReceiveTip();
    }

    private void OnDisable()
    {
        celebSpottedVRcontroller.action.performed -= Action_performed;
        celebSpottedKeyboard.action.performed -= Action_performed;
    }
}
