using System;
using System.Collections.Generic;
using UnityEngine.UI;

internal class SpellCardTypeDropDown : IActionDropdownInfo
{
    private CreatureTypeDropDownInfo creatureTypeDropDown;
    private Stat1TypeDropDown stat1TypeDropDown;
    private Stat2TypeDropDown stat2TypeDropDown;

    public SpellCardTypeDropDown(Dropdown creatureTypeDropDown, Dropdown stat1TypeDropDown, Dropdown stat2TypeDropDown)
    {
        this.creatureTypeDropDown = new CreatureTypeDropDownInfo(creatureTypeDropDown);
        this.stat1TypeDropDown = new Stat1TypeDropDown(stat1TypeDropDown, "Not used for spells");
        this.stat2TypeDropDown = new Stat2TypeDropDown(stat2TypeDropDown, "Not used for spells");
    }

    public List<string> GetDropDownInput()
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return CardType.Spell.ToString();
    }

    public bool HasSublist()
    {
        return false;
    }

    public void SelectValue(int index)
    {
        creatureTypeDropDown.SetInteractable(false);
        stat1TypeDropDown.SetInteractable(false);
        stat2TypeDropDown.SetInteractable(false);
    }
}