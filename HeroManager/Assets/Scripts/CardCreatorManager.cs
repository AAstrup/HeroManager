using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardCreatorManager  {

    Deck _deck;
    List<int> _cardCopiesToCreate;

	public CardCreatorManager(Deck deck, List<int> cardCopiesToCreate)
    {
        _deck = deck;
        _cardCopiesToCreate = cardCopiesToCreate;
    }

    public void Initialize(References Ref)
    {
        GameObject gmj = Ref.GetCardCreationUI();

    }
}
