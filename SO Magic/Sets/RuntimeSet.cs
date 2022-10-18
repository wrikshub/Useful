using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Runtime Set")]
public class RuntimeSet : ScriptableObject
{
    [HideInInspector] public List<GameObject> objects = new List<GameObject>();

    public GameObject PickRandomObject()
    {
        return objects[Random.Range(0, objects.Count)];
    }
}
