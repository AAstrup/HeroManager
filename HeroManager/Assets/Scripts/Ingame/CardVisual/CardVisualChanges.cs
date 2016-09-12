using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardVisualChanges
{

    public CardVisual _target;
    public Dictionary<Stat, int> _statChanges;

    public CardVisualChanges(CardVisual target,Dictionary<Stat, int> statchanges)
    {
        _target = target;
        _statChanges = statchanges;
    }

}