using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

internal class Stat2TypeDropDown : IActionDropdownInfo
{
    private Dropdown stat2TypeDropDown;
    private List<int> values;
    private string _name;
    private int selectedIndex;

    public Stat2TypeDropDown(Dropdown stat2TypeDropDown, string name)
    {
        this.stat2TypeDropDown = stat2TypeDropDown;
        _name = name;

        stat2TypeDropDown.onValueChanged.AddListener(delegate {
            SelectValue(stat2TypeDropDown.value);
        });

        values = new List<int>();
        for (int i = 1; i < 11; i++)
        {
            values.Add(i);
        }
        stat2TypeDropDown.captionText.text = GetDropDownInput()[0];
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
        stat2TypeDropDown.value = selectedIndex;
        stat2TypeDropDown.options.Clear();
        foreach (string v in GetDropDownInput())
        {
            stat2TypeDropDown.options.Add(new Dropdown.OptionData(v));
        }
    }

    internal void SetInteractable(bool v)
    {
        stat2TypeDropDown.interactable = v;
    }
}