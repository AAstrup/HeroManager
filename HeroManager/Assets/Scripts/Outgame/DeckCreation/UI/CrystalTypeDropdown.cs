using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class CrystalTypeDropdown : IActionDropdownInfo
{
    CrystalTypeDropdown _child;
    private Dropdown dropdown;
    List<CardColor> colors;
    int selectedIndex;

    public CrystalTypeDropdown(Dropdown dropdown)
    {
        this.dropdown = dropdown;
        InsertOptions(new List<CardColor>());
    }

    private void InsertOptions(List<CardColor> usedColors)
    {
        colors = new List<CardColor>();
        foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
        {
            if(!usedColors.Contains(color))
                colors.Add(color);
        }

        dropdown.options.Clear();
        foreach (var color in colors)
        {
            dropdown.options.Add(new Dropdown.OptionData(color.ToString()));
        }
        SelectValue(0);

        dropdown.captionText.text = GetDropDownInput()[0];
    }

    internal void SetChild(CrystalTypeDropdown child)
    {
        _child = child;
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(colors.Select(x => x.ToString()));
    }

    public string GetName()
    {
        return "Crystal type";
    }

    public bool HasSublist()
    {
        return true;
    }

    public void SelectValue(int index)
    {
        selectedIndex = index;
        if (_child != null)
            _child.Update(new List<CardColor>() { colors[selectedIndex] });
    }

    private void Update(List<CardColor> usedColors)
    {
        InsertOptions(usedColors);
        usedColors.Add(colors[selectedIndex]);
        if (_child != null)
            _child.Update(usedColors);
    }
}