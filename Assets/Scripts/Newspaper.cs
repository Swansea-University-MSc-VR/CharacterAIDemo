using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    public delegate void NewspaperAnnouncementHandler();
    public static event  NewspaperAnnouncementHandler onCelebritySpottedAtCafe;

    public bool triggerOnEnable;

    private void OnEnable()
    {
        if (triggerOnEnable)
            ReceiveTip();        
    }

    public void ReceiveTip()
    {
        onCelebritySpottedAtCafe.Invoke();
    }
}
