using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDrawn : Trigger
{
    private SpriteRenderer srend;
    private void Start()
    {
        srend = GetComponentInChildren<SpriteRenderer>();
        if (!debugMode) srend.enabled = false;
    }
}
