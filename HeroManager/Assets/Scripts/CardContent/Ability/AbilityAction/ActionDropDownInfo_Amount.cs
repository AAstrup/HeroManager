using System;
using System.Collections.Generic;
using System.Linq;

public class ActionDropDownInfo_Amount : IActionDropdownInfo
{
    List<IActionDropdownInfo> _dropdowns;
    List<IGetIntValue> _dropdownValue;
    int selectedIndex;

    public IActionProcess _process;

    public ActionDropDownInfo_Amount(List<IActionDropdownInfo> dropdowns,List<IGetIntValue> dropdownValue
        , IActionProcess process)
    {
        _dropdowns = dropdowns;
        _process = process;
        selectedIndex = -1;
        SelectValue(0);
    }

    //SelectValue(0,_dropdowns[selectedIndex].HasSublist()); sådan skal den kaldes i alle andre tilfælde
    public void SelectValue(int index)
    {
        _process.UpdateDropdowns(this, selectedIndex!=-1 ? _dropdowns[selectedIndex].HasSublist() : false, _dropdowns[index].HasSublist(), _dropdowns[selectedIndex]);
        selectedIndex = index;
    }



    public int GetValue()
    {
        return _dropdownValue[selectedIndex].GetValue();
    }

    public bool HasSublist()
    {
        return true;
    }

    public List<string> GetDropDownInput()
    {
        return new List<string>(_dropdowns.Select(typ => typ.GetName()));
    }

    public string GetName()
    {
        return "ActionDropDownInfo_Dropdowns_Int";
    }
}