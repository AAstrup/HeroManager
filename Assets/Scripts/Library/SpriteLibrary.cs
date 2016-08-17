using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLibrary
{
    public Dictionary<string, Sprite> Sprites;

    public void Initialize()
    {
        Sprites = new Dictionary<string, Sprite>();

        foreach (Sprite pre in Resources.LoadAll("Sprites", typeof(Sprite)))
        {
            Sprites.Add(pre.name, pre);
        }

    }
}