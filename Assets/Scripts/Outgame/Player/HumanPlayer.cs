using UnityEngine;
using System.Collections;
using System;

public class HumanPlayer : PlayerAbstract, IPlayer
{
    public HumanPlayer(string name) : base(name)
    {

    }

    public Deck GetDeck()
    {
        return _deck;
    }

    public string GetName()
    {
        return _name;
    }

    public bool IsHuman()
    {
        return true;
    }
}
