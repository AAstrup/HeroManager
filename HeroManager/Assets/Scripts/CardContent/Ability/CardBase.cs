using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class CardBase {

    public int _id;
    public int _cost;
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
        _cost = 1;
        _stat1 = 1;
        _stat2 = 1;
        _cardType = CardType.Creature;


        _effects = new List<Ability>() {  };

        _creatureType = CreatureType.Beast;
        _name = "Card name";
        _flavorText = "Fancy text";
    }

    public void SetName(string arg0)
    {
        _name = arg0;
    }

    public void SetFlavourText(string arg0)
    {
        _flavorText = arg0;
    }

    public CardBase(int id,int cost,int attack, int hp,CardType cardType,List<Ability> effects,string name, string flavorText, CreatureType creatureType)
    {
        _id = id;
        _cost = cost;
        _stat1 = attack;
        _stat2 = hp;
        _cardType = cardType;
        _effects = effects;
        _name = name;
        _flavorText = flavorText;
        _creatureType = creatureType;
    }

    internal void SetCreatureType(Dropdown drop)
    {
        if (drop.interactable == true)
        {
            string val = drop.options[drop.value].text.ToString();
            _creatureType = (CreatureType)Enum.Parse(typeof(CreatureType), val);
        }
    }

    internal void SetStat1(Dropdown drop)
    {
        if (drop.interactable == true)
        {
            string val = drop.options[drop.value].text.ToString();
            _stat1 = (int) int.Parse(val);
        }
    }

    internal void SetCardType(Dropdown drop)
    {
        if (drop.interactable == true) {
            string val = drop.options[drop.value].text.ToString();
            _cardType =(CardType) Enum.Parse(typeof(CardType), val);
        }
    }

    internal void SetStat2(Dropdown drop)
    {
        if (drop.interactable == true)
        {
            string val = drop.options[drop.value].text.ToString();
            _stat2 = (int)int.Parse(val);
        }
    }

    public string GetDescription(int index)
    {
        return _effects[index].Explained();
    }
}

public enum CardType { Creature, Spell, Weapon, All }
public enum CreatureType { None, Mech, Beast, Dragon, Pirate, All}

