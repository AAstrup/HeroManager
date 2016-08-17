using System;
using System.Collections.Generic;
using System.Linq;

public class CreatureDropDown : IActionDropdownInfo
{
    public CardBaseLibrary library;
    public List<CreatureType> creatureTypes;
    int selectedIndex;

    public CreatureDropDown(CardBaseLibrary library)
    {
        this.library = library;
        foreach (CreatureType type in Enum.GetValues(typeof(CreatureType)))
        {
            creatureTypes.Add(type);
        }
    }

    public List<string> GetDropDownInput()
    {
        return creatureTypes.Select(x => x.ToString()).ToList();
    }

    public string GetName()
    {
        return "Creature Types";
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