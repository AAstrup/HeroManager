using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using UnityEditor;

public abstract class CardActive
{
    public long ID;

    private InGameController _IGC;

    public BoardState.Player _owner;
    public CardBase Base;

    public Dictionary<Stat, int> Stats;
    //Stats fra base skal sættes her i Stats-dictionariet :)

    public void BaseInit(InGameController igc,CardBase cardbase,BoardState.Player owner) //JUST TO MAKE SURE ALL STATS ARE SAT AND THERE WILL BE NO "ERROR VARIABLE NOT SAT TO THE INSTANCE OF AN OBJECT" :P
    {
        Stats[Stat.CreatureType] = Convert.ToInt32(cardbase._creatureType);
        Stats[Stat.Stat1] = cardbase._stat1;
        Stats[Stat.Stat2] = cardbase._stat2;

        if (cardbase._costs.Count >= 1)
        {
            Stats[Stat.PrimColor] = Convert.ToInt32(cardbase._costs[0]._color);
            Stats[Stat.PrimCost] = cardbase._costs[0]._amount;
        }
        if (cardbase._costs.Count >= 2)
        {
            Stats[Stat.PrimColor] = Convert.ToInt32(cardbase._costs[1]._color);
            Stats[Stat.PrimCost] = cardbase._costs[1]._amount;
        }
        if (cardbase._costs.Count >= 3)
        {
            Stats[Stat.PrimColor] = Convert.ToInt32(cardbase._costs[2]._color);
            Stats[Stat.PrimCost] = cardbase._costs[2]._amount;
        }

        Base = cardbase;
        _owner = owner;

        _IGC = igc;
        ID = _IGC.IdGenerator.GetID(this);
        Stats = new Dictionary<Stat, int>();

        foreach (Stat stat in Enum.GetValues(typeof(Stat)).Cast<Stat>())
        {
            Stats.Add(stat,0);
        }
    }

    public virtual void Play()
    {
        
    }

    public override bool Equals(object obj)
    {
        return GetType() == obj.GetType() && ID == ((CardActive)obj).ID;
    }
    public override int GetHashCode()
    {
        return Convert.ToInt32(ID);
    }
}

public enum Stat
{
    Stat1,
    Stat2,
    PrimCost,
    PrimColor,
    SecCost,
    SecColor,
    TetCost,
    TetColor,
    CreatureType
}