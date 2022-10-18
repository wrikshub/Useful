using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://bernardopacheco.net/using-an-event-manager-to-decouple-your-game-in-unity

[CreateAssetMenu(menuName = "Game Events/Manager")]
public class SOEventManager : ScriptableObject
{
    private Dictionary<string, Action<Dictionary<string, object>>> eventDictionary = new Dictionary<string, Action<Dictionary<string, object>>>();
    
    public void StartListening(string eventName, Action<Dictionary<string, object>> listener) {
        Action<Dictionary<string, object>> thisEvent;
    
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        } else {
            thisEvent += listener;
            eventDictionary.Add(eventName, thisEvent);
        }
    }
    
    public void StopListening(string eventName, Action<Dictionary<string, object>> listener) {
        Action<Dictionary<string, object>> thisEvent;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }
    
    public void TriggerEvent(string eventName, Dictionary<string, object> message) {
        Action<Dictionary<string, object>> thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke(message);
        }
    }
}
