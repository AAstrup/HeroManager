using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck {

    int maxCards = 30;
    List<CardBase> deck;

    public void Add(CardBase card)
    {
        if (maxCards <= deck.Count)
            deck.Add(card);
        else
            throw new System.Exception("Deck aleredy full");
    }
}
