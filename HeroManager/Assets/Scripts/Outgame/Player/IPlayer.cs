using UnityEngine;
using System.Collections;

public interface IPlayer {
    void IncreasePoints(int value);
    int GetPoints();
    void ResetScore();
    Division GetDivision();
    void SetDivision(Division division);
    string GetName();
    bool IsHuman();
    bool JustSwitchedDivision();
    Deck GetDeck();
    void SetDeck(Deck deck);
}
