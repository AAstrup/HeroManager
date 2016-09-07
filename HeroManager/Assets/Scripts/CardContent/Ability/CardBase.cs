using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[Serializable]
public class CardBase {
    
    public int _id;
    public List<CardCost> _costs;
    public int _stat1;//creature attack or weapon attack

    internal void SetID(int count)
    {
        _id = count;
    }
    
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
        _costs = new List<CardCost>(){
            new CardCost(CardColor.White, 10,0),
            new CardCost(CardColor.Red, 0,0),
            new CardCost(CardColor.Green, 0,0)
        };
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

   internal void SetCreatureType(Dropdown drop)
    {
        if (drop.interactable == true)
        {
            string val = drop.options[drop.value].text.ToString();
            _creatureType = (CreatureType)Enum.Parse(typeof(CreatureType), val);
        }
    }

   public void SetName(string arg0)
   {
       _name = arg0;
   }

   public void SetFlavourText(string arg0)
   {
       _flavorText = arg0;
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

    public string GetCardText()
    {
        //"Her bør alle dens relevante effekter skrives"
        return "No effect";
    }

    public void SetCrystalType(int index, Dropdown drop)
    {
         if (drop.interactable == true)
        {
            string val = drop.options[drop.value].text.ToString();
            _costs[index]._color = (CardColor)Enum.Parse(typeof(CardColor), val);
        }
    }

    public CardColor GetCrystalType(int crystalNumberIndex)
    {
        return _costs[crystalNumberIndex]._color;
    }

    public void SetCrystalAmount(int index, Dropdown drop)
    {
        if (drop.interactable == true)
        {
            string val = drop.options[drop.value].text.ToString();
            if(val.Equals("None"))
                _costs[index]._percentageAmount = 0;
            else //comes at format as "10%"
                _costs[index]._percentageAmount = (int)int.Parse(val.Substring(0,val.Length - 1));
        }
    }
}

public enum CardType { Creature, Spell, Weapon, All }
public enum CreatureType { None, Mech, Beast, Dragon, Pirate, All}
