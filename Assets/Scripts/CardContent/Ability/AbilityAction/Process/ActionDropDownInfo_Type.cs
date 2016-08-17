using System;
using System.Collections.Generic;
using System.Linq;

public class ActionDropDownInfo_Type : IActionDropdownInfo
{
    public List<IActionDropdownInfo> _dropdowns;
    public List<CardType> values;
    public int selectedIndex;

    public CreatureDropDown creatureDropDown;
    public SpellDropDown spellDropDown;
    public WeaponDropDown weaponDropDown;


    public ActionDropDownInfo_Type(CardBaseLibrary library)
    {
        values = new List<CardType>();
        foreach (CardType type in Enum.GetValues(typeof(CardType)))
        {
            values.Add(type);
        }

        creatureDropDown = new CreatureDropDown(library);
        _dropdowns.Add(creatureDropDown);
        spellDropDown = new SpellDropDown(library);
        _dropdowns.Add(spellDropDown);
        weaponDropDown = new WeaponDropDown(library);
        _dropdowns.Add(weaponDropDown);
    }

    public List<string> GetDropDownInput()
    {
        return values.Select(x => x.ToString()).ToList();
    }

    public string GetName()
    {
        return "Cardtype";
    }

    public bool HasSublist()
    {
        return true;
    }

    public void SelectValue(int index)
    {
        selectedIndex = index;
    }
}