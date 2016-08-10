using UnityEngine;
using System.Collections;
using System;

public class DeckFactory : IDeckFactory
{

	public void Initialize()
    {

    }

    public Deck GenerateDefaultDeck()
    {
        Deck deck = new Deck();
        for (int i = 0; i < 30; i++)
        {
            deck.Add(new CardBase());
        }
        return deck;
    }

    public Deck GeneratePlayerStartDeck()
    {
        return GenerateDefaultDeck();
    }

    public Deck GenerateAIDeck(IDeckFactory factory)
    {
        return GenerateDefaultDeck();
    }
}
