using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] internal LayerMask layer;
    [SerializeField] internal bool interactOnlyOnce = false;
    [SerializeField] internal bool debugMode = false;
    
    public event InteractedWith OnInteractorEnter;
    public event InteractedWith OnInteractorExit;

    public delegate void InteractedWith(Collider2D interactor);

    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;

    internal virtual void OnTriggerEnter2D(Collider2D other)
    {
        InteractionEnter(other);
    }

    internal virtual void OnTriggerExit2D(Collider2D other)
    {
        InteractionExit(other);
    }

    private void InteractionEnter(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & layer) == 0) return;
        OnEnter?.Invoke();
        OnInteractorEnter?.Invoke(other);
    }

    private void InteractionExit(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & layer) == 0) return;
        OnExit?.Invoke();
        OnInteractorExit?.Invoke(other);

        if (interactOnlyOnce)
        {
            Destroy(gameObject);
        }
    }
}