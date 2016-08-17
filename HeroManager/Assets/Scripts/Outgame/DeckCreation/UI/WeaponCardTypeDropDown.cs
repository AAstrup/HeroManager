using System;
using System.Collections.Generic;
using UnityEngine.UI;

internal class WeaponCardTypeDropDown : IActionDropdownInfo
{
    private CreatureTypeDropDownInfo creatureTypeDropDown;
    private Stat1TypeDropDown stat1TypeDropDown;
    private Stat2TypeDropDown stat2TypeDropDown;

    public WeaponCardTypeDropDown(Dropdown creatureTypeDropDown, Dropdown stat1TypeDropDown, Dropdown stat2TypeDropDown)
    {
        this.creatureTypeDropDown = new CreatureTypeDropDownInfo(creatureTypeDropDown);
        this.stat1TypeDropDown = new Stat1TypeDropDown(stat1TypeDropDown,"Attack");
        this.stat2TypeDropDown = new Stat2TypeDropDown(stat2TypeDropDown,"Durability");
    }

    public List<string> GetDropDownInput()
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return CardType.Weapon.ToString();
    }

    public bool HasSublist()
    {
        return false;
    }

    public void SelectValue(int index)
    {
        creatureTypeDropDown.SetInteractable(false);
        stat1TypeDropDown.SetInteractable(true);
        stat2TypeDropDown.SetInteractable(true);
        
        stat1TypeDropDown.SelectValue(0);
        stat2TypeDropDown.SelectValue(0);
    }
}