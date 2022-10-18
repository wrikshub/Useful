using System;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class UnityEventWithArgs : UnityEvent<object>
{
    
}

public class SOEventListener : MonoBehaviour
{
    public SOEvent SOevent;
    public UnityEventWithArgs eventWithArgs;
    
    private void Start()
    {
        SOevent.OnFired += Invoked;
    }

    private void OnDisable()
    {
        SOevent.OnFired -= Invoked;
    }

    private void Invoked(object args)
    {
        eventWithArgs?.Invoke(args);
    }
}
