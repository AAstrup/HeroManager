using UnityEngine;
using System.Collections;
using System;

public class AIPlayer : PlayerAbstract, IPlayer
{
    AIMoneyBehavior _moneyBehavior;
    AISetupStrategy _setupStrategy;
    public AIPlayer(string name, AIMoneyBehavior moneyBehavior, AISetupStrategy setupStrategy) : base(name)
    {
        _moneyBehavior = moneyBehavior;
        _setupStrategy = setupStrategy;
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
        return false;
    }
}
public enum AIMoneyBehavior { Saver, Spender }
public enum AISetupStrategy { Agressive, Defensive }