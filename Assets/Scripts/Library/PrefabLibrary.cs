using System.Collections.Generic;
using UnityEngine;

public class PrefabLibrary
{

    public Dictionary<string, GameObject> Prefabs;

    public void Initialize()
    {
        Prefabs = new Dictionary<string, GameObject>();

        foreach (GameObject pre in Resources.LoadAll("Prefabs", typeof(GameObject)))
        {
            Prefabs.Add(pre.name, pre);
        }

    }

}