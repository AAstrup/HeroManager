using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class CardActive
{
    public CardVisual Visual;
    public long ID;

    public InGameController _IGC;

    public BoardState.Player _owner;
    private CardBase Base;

    public Dictionary<Stat, int> Stats;

    public void BaseInit(InGameController igc,CardBase cardbase,BoardState.Player owner) //JUST TO MAKE SURE ALL STATS ARE SAT AND THERE WILL BE NO "ERROR VARIABLE NOT SAT TO THE INSTANCE OF AN OBJECT" :P
    {
        _IGC = igc;
        ID = _IGC.IdGenerator.GetID(this);

        Stats = new Dictionary<Stat, int>();
        foreach (Stat stat in Enum.GetValues(typeof(Stat)).Cast<Stat>())
        {
            Stats.Add(stat, 0);
        }

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
            Stats[Stat.SecColor] = Convert.ToInt32(cardbase._costs[1]._color);
            Stats[Stat.SecCost] = cardbase._costs[1]._amount;
        }
        if (cardbase._costs.Count >= 3)
        {
            Stats[Stat.TetColor] = Convert.ToInt32(cardbase._costs[2]._color);
            Stats[Stat.TetCost] = cardbase._costs[2]._amount;
        }

        Base = cardbase;
        _owner = owner;

        Visual = new CardVisual(_IGC.CreateGameObject(_IGC._libraries.prefabLibrary.Prefabs["Card"]));
        _IGC.CanvasController.AddUIGameObject(Visual.GB);
        _IGC.CardVisualizer.VisualizeInit(this);

        //TEMP//
        Visual.rect.anchoredPosition = new Vector2(Random.Range(-300, 300), Random.Range(-200, 200));
        ///////
    }

    public virtual void Play()
    {
        _IGC.BoardState.PlayerContents[_owner].ManaGems.Where(typ => typ._color == GetCardColor(Stats[Stat.PrimColor]) && !typ._used).Take(Stats[Stat.PrimCost]).ToList().ForEach(typ => typ._used = true);
        _IGC.BoardState.PlayerContents[_owner].ManaGems.Where(typ => typ._color == GetCardColor(Stats[Stat.SecColor]) && !typ._used).Take(Stats[Stat.SecCost]).ToList().ForEach(typ => typ._used = true);
        _IGC.BoardState.PlayerContents[_owner].ManaGems.Where(typ => typ._color == GetCardColor(Stats[Stat.TetColor]) && !typ._used).Take(Stats[Stat.TetCost]).ToList().ForEach(typ => typ._used = true);
    }

    public override bool Equals(object obj)
    {
        return GetType() == obj.GetType() && ID == ((CardActive)obj).ID;
    }
    public override int GetHashCode()
    {
        return Convert.ToInt32(ID);
    }

    public CardBase GetCardBase()
    {
        return Base;
    }

    public bool Playable()
    {
        _IGC.Log("RELEVANT MANA: " + _IGC.BoardState.PlayerContents[_owner].ManaGems.Count(typ => typ._color == GetCardColor(Stats[Stat.PrimColor]) && !typ._used).ToString());
        if (Stats[Stat.PrimCost] >
            _IGC.BoardState.PlayerContents[_owner].ManaGems.Count(typ => typ._color == GetCardColor(Stats[Stat.PrimColor]) && !typ._used))
        {
            _IGC.Log("Not enough mana. Need " + Stats[Stat.PrimCost]);
            return false;
        }
        if (Stats[Stat.SecCost] >
            _IGC.BoardState.PlayerContents[_owner].ManaGems.Count(typ => typ._color == GetCardColor(Stats[Stat.SecColor]) && !typ._used))
        {
            _IGC.Log("Not enough mana. Second. Need " + Stats[Stat.SecCost]);
            return false;
        }
        if (Stats[Stat.TetCost] >
            _IGC.BoardState.PlayerContents[_owner].ManaGems.Count(typ => typ._color == GetCardColor(Stats[Stat.TetColor]) && !typ._used))
        {
            _IGC.Log("Not enough mana. Third. Need " + Stats[Stat.TetCost]);
            return false;
        }
        return true;
    }

    public CardColor GetCardColor(int i)
    {
        return Enum.GetValues(typeof (CardColor)).Cast<CardColor>().ToList()[i];
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