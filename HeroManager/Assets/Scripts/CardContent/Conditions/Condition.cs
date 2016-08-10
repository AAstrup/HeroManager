using System;
using System.Collections.Generic;

public class Condition
{
    public List<EventCondition> eventCondition;
    public List<IBoardCondition> boardCondition;
    public List<ISelectCondition> selectCondition;

    internal string Explained()
    {
        return "Write later";
    }
}

public enum EventCondition
{
    Battlecry,
    Deathrattle,
    WhenTheTurnStart,
    WhenTheTurnEnd,
    WhenYourTurnStart,
    WhenYourTurnEnd,
    WhenUnitDies,
    WhenUnitPlayed
}