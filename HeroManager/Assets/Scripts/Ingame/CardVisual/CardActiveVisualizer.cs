using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System;

public class CardActiveVisualizer
{
    private LibrariesContainer _libraries;

    public CardActiveVisualizer(LibrariesContainer libraries)
    {
        _libraries = libraries;
    }

    public void VisualizeInit(CardActive cardactive) //Updateobject skal kun være true, hvis du vil ændre på hvilke dele af kortet der er synlige.
    //for eksempel; hvis man går fra 1 crystal til 2 crystaler, skal den være true, da den anden crystal skal enables.
    {
        UpdateObjects(cardactive);

        cardactive.Visual.Texts["Text"].text = cardactive.GetCardBase().GetCardText();
        cardactive.Visual.Texts["Stat1Text"].text = cardactive.GetCardBase()._stat1.ToString();
        cardactive.Visual.Texts["Stat2Text"].text = cardactive.GetCardBase()._stat2.ToString();
        cardactive.Visual.Texts["Title"].text = cardactive.GetCardBase()._name;
        cardactive.Visual.Texts["Type"].text = cardactive.GetCardBase()._creatureType.ToString();

        cardactive.Visual.Images["CardBack"].sprite = _libraries.spriteLibrary.Sprites["CardBack" + cardactive.GetCardBase()._costs[0]._color.ToString()];

        for (int i = 0; i < cardactive.GetCardBase()._costs.Count; i++)
        {
            cardactive.Visual.Images["CrystalBack" + (i + 1)].sprite = _libraries.spriteLibrary.Sprites["Crystal" + cardactive.GetCardBase()._costs[i]._color.ToString()];
            cardactive.Visual.Texts["CrystalText" + (i + 1)].text = cardactive.GetCardBase()._costs[i]._amount.ToString();
        }

    }

    public void Visualize(CardVisualChanges changes)
    {
        changes._statChanges.Keys.ToList().ForEach(typ => ChangeVisualStat(changes._target, typ, changes._statChanges[typ]));
    }

    public void ChangeVisualStat(CardVisual target, Stat stat, int value)
    {
        switch (stat)
        {

            case Stat.Stat1:
                {
                    target.Texts["Stat1Text"].text = value.ToString();
                    break;
                }
            case Stat.Stat2:
                {
                    target.Texts["Stat2Text"].text = value.ToString();
                    break;
                }
            case Stat.PrimColor:
                {
                    target.Images["CrystalBack1"].sprite = _libraries.spriteLibrary.Sprites["Crystal" + Enum.GetValues(typeof(CardColor)).Cast<CardColor>().ToList()[value].ToString()];
                    break;
                }
            case Stat.SecColor:
                {
                    target.Images["CrystalBack2"].sprite = _libraries.spriteLibrary.Sprites["Crystal" + Enum.GetValues(typeof(CardColor)).Cast<CardColor>().ToList()[value].ToString()];
                    break;
                }
            case Stat.TetColor:
                {
                    target.Images["CrystalBack3"].sprite = _libraries.spriteLibrary.Sprites["Crystal" + Enum.GetValues(typeof(CardColor)).Cast<CardColor>().ToList()[value].ToString()];
                    break;
                }
            case Stat.PrimCost:
                {
                    target.Texts["CrystalText1"].text = value.ToString();
                    break;
                }
            case Stat.SecCost:
                {
                    target.Texts["CrystalText2"].text = value.ToString();
                    break;
                }
            case Stat.TetCost:
                {
                    target.Texts["CrystalText3"].text = value.ToString();
                    break;
                }

        }
    }

    public void UpdateObjects(CardActive cardactive)
    {
        if (cardactive.GetCardBase()._cardType == CardType.Creature || cardactive.GetCardBase()._cardType == CardType.Weapon)
        {
            cardactive.Visual.Texts["Stat1Text"].transform.gameObject.SetActive(true);
            cardactive.Visual.Images["Stat1Back"].transform.gameObject.SetActive(true);
            cardactive.Visual.Texts["Stat2Text"].transform.gameObject.SetActive(true);
            cardactive.Visual.Images["Stat2Back"].transform.gameObject.SetActive(true);
        }
        else
        {
            cardactive.Visual.Texts["Stat1Text"].transform.gameObject.SetActive(false);
            cardactive.Visual.Images["Stat1Back"].transform.gameObject.SetActive(false);
            cardactive.Visual.Texts["Stat2Text"].transform.gameObject.SetActive(false);
            cardactive.Visual.Images["Stat2Back"].transform.gameObject.SetActive(false);
        }

        if (cardactive.GetCardBase()._costs[2]._percentageAmount > 0)
        {
            cardactive.Visual.Images["CrystalBack1"].transform.gameObject.SetActive(true);
            cardactive.Visual.Texts["CrystalText1"].transform.gameObject.SetActive(true);
            cardactive.Visual.Images["CrystalBack2"].transform.gameObject.SetActive(true);
            cardactive.Visual.Texts["CrystalText2"].transform.gameObject.SetActive(true);
            cardactive.Visual.Images["CrystalBack3"].transform.gameObject.SetActive(true);
            cardactive.Visual.Texts["CrystalText3"].transform.gameObject.SetActive(true);
        }
        else if (cardactive.GetCardBase()._costs[1]._percentageAmount > 0)
        {
            cardactive.Visual.Images["CrystalBack1"].transform.gameObject.SetActive(true);
            cardactive.Visual.Texts["CrystalText1"].transform.gameObject.SetActive(true);
            cardactive.Visual.Images["CrystalBack2"].transform.gameObject.SetActive(true);
            cardactive.Visual.Texts["CrystalText2"].transform.gameObject.SetActive(true);
            cardactive.Visual.Images["CrystalBack3"].transform.gameObject.SetActive(false);
            cardactive.Visual.Texts["CrystalText3"].transform.gameObject.SetActive(false);
        }
        else if (cardactive.GetCardBase()._costs[0]._percentageAmount > 0)
        {
            cardactive.Visual.Images["CrystalBack1"].transform.gameObject.SetActive(true);
            cardactive.Visual.Texts["CrystalText1"].transform.gameObject.SetActive(true);
            cardactive.Visual.Images["CrystalBack2"].transform.gameObject.SetActive(false);
            cardactive.Visual.Texts["CrystalText2"].transform.gameObject.SetActive(false);
            cardactive.Visual.Images["CrystalBack3"].transform.gameObject.SetActive(false);
            cardactive.Visual.Texts["CrystalText3"].transform.gameObject.SetActive(false);
        }
        else
        {
            cardactive.Visual.Images["CrystalBack1"].transform.gameObject.SetActive(false);
            cardactive.Visual.Texts["CrystalText1"].transform.gameObject.SetActive(false);
            cardactive.Visual.Images["CrystalBack2"].transform.gameObject.SetActive(false);
            cardactive.Visual.Texts["CrystalText2"].transform.gameObject.SetActive(false);
            cardactive.Visual.Images["CrystalBack3"].transform.gameObject.SetActive(false);
            cardactive.Visual.Texts["CrystalText3"].transform.gameObject.SetActive(false);
        }
    }

}