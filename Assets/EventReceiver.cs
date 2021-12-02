using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
   public void TurnBlue()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
