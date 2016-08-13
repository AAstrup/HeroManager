using System;
using System.Collections.Generic;
using System.Linq;

public class ActionDropDownInfo_Stat : IActionDropdownInfo
{
    List<Stat> stats;
    int _index;

    public ActionDropDownInfo_Stat()
    {
        stats = new List<Stat>();
        foreach (Stat stat in Enum.GetValues(typeof(Stat)))
        {
            stats.Add(stat);
        }
    }

    public List<string> GetDropDownInput()
    {
        return stats.Select(t => t.ToString()).ToList();
    }

    public string GetName()
    {
        return "Stat";
    }

    public bool HasSublist()
    {
        return true;
    }

    public void SelectValue(int index)
    {
        _index = index;
    }

    public Stat GetStatValue()
    {
        return stats[_index];
    }
}

public enum Stat
{
    Stat1,
    Stat2,
    Cost,
    CreatureType
}
