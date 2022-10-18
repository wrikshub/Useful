using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Persistence/Persistant Player Data")]
public class PersistantData : ScriptableObject
{
    public int playerMaxHealth = 3;
    public int playerHealth = 3;
    
    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

    private void OnDisable() => playerHealth = playerMaxHealth;
}
