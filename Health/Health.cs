using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Timer timer = null;
    public event TookDamage OnTakeDamage;
    public event Death OnDeath;
    public delegate void TookDamage(int amount);
    public delegate void Death();
    [SerializeField] private int health = 1;
    [SerializeField] private float invincibilityCooldown = 1f;
    private bool canTakeDamage = true;

    private void Start()
    {
        timer = new Timer(1000000000);
        timer.OnReachedTimeLimit += OnTimerOver;
    }

    private void OnDisable()
    {
        timer.OnReachedTimeLimit -= OnTimerOver;
    }

    private void Update()
    {
        timer.UpdateTimer(Time.deltaTime);
    }

    private void OnTimerOver()
    {
        canTakeDamage = true;
    }
    
    public void Damage(int amount)
    {
        if (!canTakeDamage) return;
        
        timer.ResetTimer(invincibilityCooldown);
        canTakeDamage = false;
        health -= amount;
        health = Mathf.Max(health, 0);
        if (health == 0)
        {
            OnDeath?.Invoke();
            Die();
        }
        else
        {
            OnTakeDamage?.Invoke(amount);
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
