using System.Collections.Generic;

public abstract class CardActive
{
    BoardState.Player owner;
    CardBase Base;

    Dictionary<Stat, int> Stats;
    //Stats fra base skal sættes her i Stats-dictionariet :)

    public virtual void Play()
    {
        throw new System.Exception("This should never be called(CardActive.Play())");
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