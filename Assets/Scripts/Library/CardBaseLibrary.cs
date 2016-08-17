using System;
using System.Collections.Generic;

public class CardBaseLibrary
{
    Dictionary<string, CardBase> nameToCardBase;
    internal void Initialize()
    {
        nameToCardBase = new Dictionary<string, CardBase>();

    }

    public void AddCardBase(CardBase cardBase)
    {
        nameToCardBase.Add(cardBase._name, cardBase);
    }

    public CardBase GetCardByName(string cardName)
    {
        return nameToCardBase[cardName];
    }
}