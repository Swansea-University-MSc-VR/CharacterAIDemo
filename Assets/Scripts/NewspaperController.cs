using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewspaperController : MonoBehaviour
{
    public InputActionReference celebSpotted;
    public Newspaper newspaper;

    private void OnEnable()
    {
        celebSpotted.action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Trigger pulled, sending tip to newspaper");
        newspaper.ReceiveTip();
    }
}
