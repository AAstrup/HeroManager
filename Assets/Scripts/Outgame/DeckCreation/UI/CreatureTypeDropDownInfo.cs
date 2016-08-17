using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

internal class CreatureTypeDropDownInfo : IActionDropdownInfo
{
    private Dropdown creatureTypeDropDown;
    private List<CreatureType> creatureTypes;
    private int selectedIndex;

    public CreatureTypeDropDownInfo(Dropdown creatureTypeDropDown)
    {
        this.creatureTypeDropDown = creatureTypeDropDown;

        creatureTypeDropDown.onValueChanged.AddListener(delegate {
            SelectValue(creatureTypeDropDown.value);
        });

        creatureTypes = new List<CreatureType>();
        foreach (CreatureType type in Enum.GetValues(typeof(CreatureType)))
        {
            if(type != CreatureType.All)
                creatureTypes.Add(type);
        }

        creatureTypeDropDown.captionText.text = GetDropDownInput()[0];
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(creatureTypes.Select(x => x.ToString()));
    }

    public string GetName()
    {
        return "Creature type";
    }

    public bool HasSublist()
    {
        return true;
    }

    public void SelectValue(int index)
    {
        selectedIndex = index;
        creatureTypeDropDown.options.Clear();
        foreach (string v in GetDropDownInput())
        {
            creatureTypeDropDown.options.Add(new Dropdown.OptionData(v));
        }
        creatureTypeDropDown.value = selectedIndex;
    }

    internal void SetInteractable(bool v)
    {
        creatureTypeDropDown.interactable = v;
    }
}