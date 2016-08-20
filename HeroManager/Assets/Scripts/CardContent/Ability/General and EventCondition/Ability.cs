using System;
using System.Collections.Generic;

public class Ability
{
    public AbilityEvent abilityEvent;
    public List<Cycle> cycles;

    public Ability()
    {
        cycles = new List<Cycle>();
    }

    public void TriggerAbility(BoardState boardState, BoardState.Player player)
    {
        if (cycles.Count == 0)
            throw new Exception("Properties not set! (TriggerAbility");

        foreach (var cycle in cycles)
        {
            cycle.TriggerCycle(boardState,player);
        }
    }

    public string Explained()
    {
        return "Nothing to explain yet...";
    }

    public float GetCost(Dictionary<AbilityEvent,float> abilityEventCost)
    {
        float cyclesAmount = 0f;
        foreach (Cycle cycle in cycles)
        {
            cyclesAmount += cycle.GetCost();
        }

        return abilityEventCost[abilityEvent] * cyclesAmount;
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