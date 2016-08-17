using UnityEngine;
using System.Collections;
using System;

public class DeckFactoryMock : IDeckFactory
{
    public Deck GenerateAIDeck(IDeckFactory factory)
    {
        return new Deck();
    }

    public Deck GeneratePlayerStartDeck()
    {
        return new Deck();
    }
}
