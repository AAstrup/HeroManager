using UnityEngine;
using System.Collections;

public class CardCost
{

    public CardColor _color;
    public float _percentageAmount;
    public int _amount;

    public CardCost(CardColor color, float percentageAmount,int amount)
    {
        _color = color;
        _percentageAmount = percentageAmount;
        _amount = amount;
    }

    public void SetPercentageCost(float percentageAmount)
    {
        _percentageAmount = percentageAmount;
    }

    public void SetCost(int amount)
    {
        _amount = amount;
    }

    public void SetType(CardColor color)
    {
        _color = color;
    }
}

public enum CardColor { White, Red, Green, Blue, Yellow, Black }