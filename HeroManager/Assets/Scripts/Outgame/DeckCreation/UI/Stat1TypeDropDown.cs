using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

internal class Stat1TypeDropDown : IActionDropdownInfo
{
    private Dropdown stat1TypeDropDown;
    private List<int> values;
    private string _name;
    private int selectedIndex;

    public Stat1TypeDropDown(Dropdown stat1TypeDropDown,string name)
    {
        this.stat1TypeDropDown = stat1TypeDropDown;
        _name = name;

        stat1TypeDropDown.onValueChanged.AddListener(delegate {
            SelectValue(stat1TypeDropDown.value);
        });

        values = new List<int>();
        for (int i = 0; i < 11; i++)
        {
            values.Add(i);
        }

        stat1TypeDropDown.captionText.text = GetDropDownInput()[0];
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(values.Select(x => x.ToString()));
    }

    public string GetName()
    {
        return _name;
    }

    public bool HasSublist()
    {
        return false;
    }

    public void SelectValue(int index)
    {
        selectedIndex = index;
        stat1TypeDropDown.value = selectedIndex;
        stat1TypeDropDown.options.Clear();
        foreach (string v in GetDropDownInput())
        {
            stat1TypeDropDown.options.Add(new Dropdown.OptionData(v));
        }
    }

    internal void SetInteractable(bool v)
    {
        stat1TypeDropDown.interactable = v;
    }
}