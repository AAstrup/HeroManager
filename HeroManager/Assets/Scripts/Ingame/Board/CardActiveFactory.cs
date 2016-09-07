using System;
using UnityEditor.Animations;
using UnityEngine;
using System.Collections;

public class CardActiveFactory {

    public CardActive CreateCardActive(InGameController igc, CardBase cardbase, BoardState.Player owner)
    {
        switch (cardbase._cardType)
        {
            case CardType.Creature:
                return new Creature(igc, cardbase, owner);
            case CardType.Spell:
                return new Spell(igc, cardbase, owner);
            case CardType.Weapon:
                return new Weapon(igc, cardbase, owner);
        }
        throw new Exception("CARDTYPE NOT RECOGNIZED!");
    }

}
