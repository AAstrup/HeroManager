using UnityEngine;
using System.Collections;

public class PlayerAbstract {

    protected int points;
    public Division _division;
    protected string _name;
    bool justSwitchedDivision;
    protected Deck _deck;

    public PlayerAbstract(string name)
    {
        _name = name;
    }

    public int GetPoints()
    {
        return points;
    }

    public void IncreasePoints(int value)
    {
        points += value;
    }

    public void ResetScore()
    {
        points = 0;
    }

    public Division GetDivision() { return _division; }
    public void SetDivision(Division division) { _division = division; }

    public bool JustSwitchedDivision()
    {
        return justSwitchedDivision;
    }

    public void SetDeck(Deck deck)
    {
        _deck = deck;
    }
}
