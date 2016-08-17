using System;
using System.Collections.Generic;
using System.Linq;

public class ActionDropDownInfo_Ints : IActionDropdownInfo, IGetIntValue
{
    private List<int> ints;
    private int _index;

    public ActionDropDownInfo_Ints()
    {
        ints = new List<int>();
        for(int i=0;i<20;i++)
        {
            ints.Add(i);
        }
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(ints.Select(typ => typ.ToString()));
    }

    public string GetName()
    {
        return "Number";
    }

    public int GetValue()
    {
        return ints[_index];
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