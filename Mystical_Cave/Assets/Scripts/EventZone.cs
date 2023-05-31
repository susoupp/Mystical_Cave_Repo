using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EventZone : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent onTriggerEnterEvent;
    public UnityEngine.Events.UnityEvent onTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        onTriggerExitEvent.Invoke();
    }

    
}
