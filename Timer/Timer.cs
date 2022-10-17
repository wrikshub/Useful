using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float time = 0f;
    private float maxTime = 1f;

    public event TimeLimit OnReachedTimeLimit;
    public delegate void TimeLimit();
        
    public Timer(float _maxTime)
    {
        maxTime = _maxTime;

        /*
        while (time <= maxTime)
        {
            time += Time.deltaTime;
        }
        */
    }

    public void UpdateTimer(float deltaTime)
    {
        time += deltaTime;
        if (time >= maxTime)
        {
            OnReachedTimeLimit?.Invoke();
        }
    }

    public void ResetTimer()
    {
        time = 0;
    }
    
    public void ResetTimer(float _maxTime)
    {
        time = 0;
        maxTime = _maxTime;
    }
}
