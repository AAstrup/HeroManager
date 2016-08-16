using UnityEngine;
using System.Collections;

public class CardCost
{

    public CardColor _color;
    public int _amount;

    public CardCost(CardColor color, int amount)
    {
        _color = color;
        _amount = amount;
    }

}

public enum CardColor { White, Red, Green, Blue, Yellow, Black }