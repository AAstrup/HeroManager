using System;
using System.Collections.Generic;
using System.Linq;

internal class ActionDropDownInfo_CardStats : IActionDropdownInfo, IGetIntValue
{
    private Cycle cycle;
    List<ActionDropDownInfo_CardStats> stats;
    int _index;

    public ActionDropDownInfo_CardStats(Cycle cycle)
    {
        this.cycle = cycle;
        stats = Enum.GetValues(typeof(ActionDropDownInfo_CardStats)).Cast<ActionDropDownInfo_CardStats>().ToList();
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(stats.Select(typ => typ.ToString()));
    }

    public string GetName()
    {
        return "Stat";
    }

    public int GetValue()
    {
        return _index; //Dette index skal fungerer som et index til listen af stats.
        //Dvs. i stedet for returne en specific stat, skal denne int bruges til at finde den :)
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