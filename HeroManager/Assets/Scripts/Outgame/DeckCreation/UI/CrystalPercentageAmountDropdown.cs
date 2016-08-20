using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class CrystalPercentageAmountDropdown : IActionDropdownInfo
{
    private Dropdown dropdown;
    List<int> values;
    int selectedIndex;
    int _maxValue = 100;
    public CrystalPercentageAmountDropdown _child;
    bool _isFirst;

    public CrystalPercentageAmountDropdown(Dropdown dropdown,bool isFirst)
    {
        this.dropdown = dropdown;
        _isFirst = isFirst;
        InsertOptions();
        SelectValue(0);

        dropdown.captionText.text = GetDropDownInput()[0];
    }

    public void SetChild(CrystalPercentageAmountDropdown child)
    {
        _child = child;
    }

    private void InsertOptions()
    {
        values = new List<int>();

        int startValue = 0;
        if (_isFirst)
            startValue = 10;
        for (int i = startValue; i <= _maxValue; i += 10)
        {
            values.Add(i);
        }

        dropdown.options.Clear();
        foreach (var value in values)
        {
            string optionName = value.ToString() + "%";
            if (value == 0)
                optionName = "None";

            dropdown.options.Add(new Dropdown.OptionData(optionName));
        }
    }

    public void Update(int maxValue)
    {
        _maxValue = maxValue;
        InsertOptions();
        if (_child != null)
        {
            _child.Update(values[selectedIndex]);
        }
    }
    
    public List<string> GetDropDownInput()
    {
        List<string> toReturn = new List<string>();
        foreach (var value in values)
        {
            string optionName = value.ToString() + "%";
            if (value == 0)
                optionName = "None";

            toReturn.Add(optionName);
        }
        return toReturn;
    }

    public string GetName()
    {
        return "Crystal amount";
    }

    public bool HasSublist()
    {
        return true;
    }

    public void SelectValue(int index)
    {
        selectedIndex = index;
        if(_child != null)
            _child.Update(values[selectedIndex]);
    }
}