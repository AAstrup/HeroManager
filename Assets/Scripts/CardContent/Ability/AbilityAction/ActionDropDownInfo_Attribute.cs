using System;
using System.Collections.Generic;
using System.Linq;

public class ActionDropDownInfo_Attribute : IActionDropdownInfo
{
    List<Attribute> Attributes;
    int _index;

    public ActionDropDownInfo_Attribute()
    {
        Attributes = new List<Attribute>();
        foreach (Attribute a in Enum.GetValues(typeof(Attribute)))
        {
            Attributes.Add(a);
        }
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(Attributes.Select(typ => typ.ToString()));
    }

    public string GetName()
    {
        return "Attribute";
    }

    public bool HasSublist()
    {
        return true;
    }

    public void SelectValue(int index)
    {
        _index = index;
    }
}

public enum Attribute
{
    Divine_Shield,
    Charge,
    Stealth,
    Defender,
    Immune,
    Frozen,
    Taunt,
    Doublestrike,
    Firststrike,
    Trample,
    Poison
}