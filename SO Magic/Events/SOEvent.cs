using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/Generic")]
public class SOEvent : ScriptableObject
{
    public event Fired OnFired;
    public delegate void Fired(object args);

    public void Activate(object args)
    {
        OnFired?.Invoke(args);
    }
}
