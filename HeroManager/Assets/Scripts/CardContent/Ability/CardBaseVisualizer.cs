using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class CardBaseVisualizer
{

    public CardVisual visual;
    private LibrariesContainer _libraries;

    public CardBaseVisualizer(LibrariesContainer libraries, GameObject cardGameObject) //anchorpos er Pos X og Pos Y for kortets Recttransform
    {
        visual = new CardVisual(cardGameObject);
        _libraries = libraries;
    }

    public void Visualize(CardBase cardbase,bool updateobjects) //Updateobject skal kun være true, hvis du vil ændre på hvilke dele af kortet der er synlige.
                                                                //for eksempel; hvis man går fra 1 crystal til 2 crystaler, skal den være true, da den anden crystal skal enables.
    {
        if (updateobjects)
        {
            UpdateObjects(cardbase);
        }

        visual.Texts["Text"].text = cardbase.GetCardText();
        visual.Texts["Stat1Text"].text = cardbase._stat1.ToString();
        visual.Texts["Stat2Text"].text = cardbase._stat2.ToString();
        visual.Texts["Title"].text = cardbase._name;
        visual.Texts["Type"].text = cardbase._creatureType.ToString();

        visual.Images["CardBack"].sprite = _libraries.spriteLibrary.Sprites["CardBack" +  cardbase._costs[0]._color.ToString()];

        for(int i=0;i<cardbase._costs.Count;i++)
        {
            visual.Images["CrystalBack" + (i + 1)].sprite = _libraries.spriteLibrary.Sprites["Crystal" + cardbase._costs[i]._color.ToString()];
            visual.Texts["CrystalText" + (i + 1)].text = cardbase._costs[i]._amount.ToString();
        }

    }

    public void UpdateObjects(CardBase cardbase)
    {
        if (cardbase._cardType == CardType.Creature || cardbase._cardType == CardType.Weapon)
        {
            visual.Texts["Stat1Text"].transform.gameObject.SetActive(true);
            visual.Images["Stat1Back"].transform.gameObject.SetActive(true);
            visual.Texts["Stat2Text"].transform.gameObject.SetActive(true);
            visual.Images["Stat2Back"].transform.gameObject.SetActive(true);
        }
        else
        {
            visual.Texts["Stat1Text"].transform.gameObject.SetActive(false);
            visual.Images["Stat1Back"].transform.gameObject.SetActive(false);
            visual.Texts["Stat2Text"].transform.gameObject.SetActive(false);
            visual.Images["Stat2Back"].transform.gameObject.SetActive(false);
        }

        if (cardbase._costs[2]._percentageAmount > 0)
        {
            visual.Images["CrystalBack1"].transform.gameObject.SetActive(true);
            visual.Texts["CrystalText1"].transform.gameObject.SetActive(true);
            visual.Images["CrystalBack2"].transform.gameObject.SetActive(true);
            visual.Texts["CrystalText2"].transform.gameObject.SetActive(true);
            visual.Images["CrystalBack3"].transform.gameObject.SetActive(true);
            visual.Texts["CrystalText3"].transform.gameObject.SetActive(true);
        }
        else if (cardbase._costs[1]._percentageAmount > 0)
        {
            visual.Images["CrystalBack1"].transform.gameObject.SetActive(true);
            visual.Texts["CrystalText1"].transform.gameObject.SetActive(true);
            visual.Images["CrystalBack2"].transform.gameObject.SetActive(true);
            visual.Texts["CrystalText2"].transform.gameObject.SetActive(true);
            visual.Images["CrystalBack3"].transform.gameObject.SetActive(false);
            visual.Texts["CrystalText3"].transform.gameObject.SetActive(false);
        }
        else if (cardbase._costs[0]._percentageAmount > 0)
        {
            visual.Images["CrystalBack1"].transform.gameObject.SetActive(true);
            visual.Texts["CrystalText1"].transform.gameObject.SetActive(true);
            visual.Images["CrystalBack2"].transform.gameObject.SetActive(false);
            visual.Texts["CrystalText2"].transform.gameObject.SetActive(false);
            visual.Images["CrystalBack3"].transform.gameObject.SetActive(false);
            visual.Texts["CrystalText3"].transform.gameObject.SetActive(false);
        }
        else
        {
            visual.Images["CrystalBack1"].transform.gameObject.SetActive(false);
            visual.Texts["CrystalText1"].transform.gameObject.SetActive(false);
            visual.Images["CrystalBack2"].transform.gameObject.SetActive(false);
            visual.Texts["CrystalText2"].transform.gameObject.SetActive(false);
            visual.Images["CrystalBack3"].transform.gameObject.SetActive(false);
            visual.Texts["CrystalText3"].transform.gameObject.SetActive(false);
        }
    }

    public void SetText(string input)
    {
        visual.Texts["Text"].text = input;
    }

    public void SetTitle(string input)
    {
        visual.Texts["Title"].text = input;
    }

    public void SetType(string input)
    {
        visual.Texts["Type"].text = input;
    }

    public void SetStat1Text(string input)
    {
        visual.Texts["Stat1Text"].text = input;
    }

    public void SetStat2Text(string input)
    {
        visual.Texts["Stat2Text"].text = input;
    }
}
