using System;
using System.Collections.Generic;

public class Ability
{
    public AbilityEvent abilityEvent;
    List<Cycle> cycles;

    public Ability()
    {
    }

    public void TriggerAbility(BoardState boardState, BoardState.Player player)
    {
        foreach (var cycle in cycles)
        {
            cycle.TriggerCycle(boardState,player);
        }
    }

    public string Explained()
    {
        return "Nothing to explain yet...";
    }
}

public enum AbilityEvent
{
    None,
    Cast,//Spells only
    Battlecry,
    Deathrattle,
    Combo,
    StartOfTurn,
    StartOfYourTurn,
    EndOfTurn,
    EndOfYourTurn
}