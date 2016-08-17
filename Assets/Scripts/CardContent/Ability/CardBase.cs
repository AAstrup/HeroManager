using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardBase {

    public int _id;
    public List<CardCost> _costs;
    public int _stat1;//creature attack or weapon attack
    public int _stat2;//creature health or weapon durability
    public CardType _cardType;
    public CreatureType _creatureType;

    public List<Ability> _effects;

    public string _name;
    public string _flavorText;

    /// <summary>
    /// Creates a Card with default values
    /// </summary>
    public CardBase()
    {
        _costs = new List<CardCost>(){new CardCost(CardColor.Black,1)};
        _stat1 = 1;
        _stat2 = 1;
        _cardType = CardType.Creature;


        _effects = new List<Ability>() {  };

        _creatureType = CreatureType.Beast;
        _name = "Card name";
        _flavorText = "Fancy text";
    }
    public CardBase(int id, List<CardCost> costs, int attack, int hp, CardType cardType, List<Ability> effects, string name, string flavorText, CreatureType creatureType)
    {
        _id = id;
        _costs = costs;
        _stat1 = attack;
        _stat2 = hp;
        _cardType = cardType;
        _effects = effects;
        _name = name;
        _flavorText = flavorText;
        _creatureType = creatureType;
    }

    public string GetDescription(int index)
    {
        return _effects[index].Explained();
    }

    public string GetCardText()
    {
        return "Her bør alle dens relevante effekter skrives";
    }
}

public enum CardType { Creature, Spell, Weapon, All }
public enum CreatureType { None, Mech, Beast, Dragon, Pirate, All}
