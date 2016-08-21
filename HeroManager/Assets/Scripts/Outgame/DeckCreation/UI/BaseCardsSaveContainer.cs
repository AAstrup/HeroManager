using System;
using System.Collections.Generic;

[System.Serializable]
public class BaseCardsSaveContainer
{
    public List<CardBase> cards;

    public BaseCardsSaveContainer()
    {
        cards = new List<CardBase>();
    }
    internal void AddCard(CardBase card)
    {
        card.SetID(cards.Count);
        cards.Add(card);
    }
}