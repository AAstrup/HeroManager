using UnityEngine;
using System.Collections;

public class ManaGem
{

    public CardColor _color;
    public bool _used;

    public ManaGem(CardColor color,bool instantlyUsable)
    {
        _color = color;
        _used = !instantlyUsable;
    }

}
