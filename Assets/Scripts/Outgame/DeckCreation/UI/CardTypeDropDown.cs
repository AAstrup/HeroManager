using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

internal class CardTypeDropDown : IActionDropdownInfo
{
    private Dropdown dropDown;
    int selectedIndex;
    List<IActionDropdownInfo> values;

    public CardTypeDropDown(Dropdown cardTypeDropdown,Dropdown creatureTypeDropDown, Dropdown stat1TypeDropDown, Dropdown stat2TypeDropDown)
    {
        this.dropDown = cardTypeDropdown;
        values = new List<IActionDropdownInfo>();
        values.Add(new CreatureCardTypeDropDown(creatureTypeDropDown, stat1TypeDropDown, stat2TypeDropDown));
        values.Add(new SpellCardTypeDropDown(creatureTypeDropDown, stat1TypeDropDown, stat2TypeDropDown));
        values.Add(new WeaponCardTypeDropDown(creatureTypeDropDown, stat1TypeDropDown, stat2TypeDropDown));

        dropDown.onValueChanged.AddListener(delegate {
            SelectValue(dropDown.value);
        });

        foreach (var action in values)
        {
            dropDown.options.Add( new Dropdown.OptionData(action.GetName()));
        }
        SelectValue(0);
        
        dropDown.captionText.text = GetDropDownInput()[0];
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(values.Select(typ => typ.GetName()));
    }

    public string GetName()
    {
        return "Card Type";
    }

    public bool HasSublist()
    {
        return true;
    }

    public void SelectValue(int index)
    {
        selectedIndex = index;
        values[selectedIndex].SelectValue(0);
    }
}