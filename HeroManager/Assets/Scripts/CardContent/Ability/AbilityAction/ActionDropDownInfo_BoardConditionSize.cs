using System;
using System.Collections.Generic;

internal class ActionDropDownInfo_BoardConditionSize : IActionDropdownInfo, IGetIntValue
{
    private Cycle cycle;
    private string name;

    public ActionDropDownInfo_BoardConditionSize(Cycle cycle)
    {
        this.cycle = cycle;
        name = "Number of targets in cycle + " + cycle._no.ToString();
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>();
    }

    public string GetName()
    {
        return name;
    }

    public int GetValue()
    {
        return cycle.GetSelectConditionSize();
    }

    public bool HasSublist()
    {
        return false;
    }

    public void SelectValue(int index)
    {
        throw new Exception("Doesn't contain a list and value cannot be selected - should never be called!");
    }
}