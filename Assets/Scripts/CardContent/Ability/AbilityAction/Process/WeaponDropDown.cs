using System;
using System.Collections.Generic;

public class WeaponDropDown : IActionDropdownInfo
{
    public CardBaseLibrary library;

    public WeaponDropDown(CardBaseLibrary library)
    {
        this.library = library;
    }

    public List<string> GetDropDownInput()
    {
        throw new Exception("This should not be called!");
    }

    public string GetName()
    {
        return "Weapon";
    }

    public bool HasSublist()
    {
        return false;
    }

    public void SelectValue(int index)
    {
        throw new Exception("This shoud never be called!");
    }
}