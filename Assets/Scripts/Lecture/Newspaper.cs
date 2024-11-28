using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Newspaper : MonoBehaviour
{
    public delegate void NewspaperAnnouncementHandler();
    public static event  NewspaperAnnouncementHandler OnCelebritySpottedAtCafe;

    public bool triggerOnEnable;

    private void OnEnable()
    {
        if (triggerOnEnable)
            ReceiveTip();
    }

    public void ReceiveTip()
    {
        OnCelebritySpottedAtCafe.Invoke();
    }
}
