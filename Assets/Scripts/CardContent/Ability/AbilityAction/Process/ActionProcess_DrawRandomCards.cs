using System;
using System.Collections.Generic;

internal class ActionProcess_DrawRandomCards : IActionProcess
{
    List<IActionDropdownInfo> Infos;
    ActionDropDownInfo_Amount intGetter;
    ActionDropDownInfo_Stat statGetter;
    ActionDropDownInfo_Attribute attributeGetter;
    ActionDropDownInfo_Type typeGetter;

    public ActionProcess_DrawRandomCards(List<Cycle> cycles,CardBaseLibrary library)
    {
        //--- Amount ---
        var dropDownInt = new ActionDropDownInfo_Ints();
        var DropdownsInfos = new List<IActionDropdownInfo>() { dropDownInt };
        var DropdownsValues = new List<IGetIntValue>() { dropDownInt };
        foreach (var cycle in cycles)
        {
            var boardCondition = new ActionDropDownInfo_BoardConditionSize(cycle);
            DropdownsInfos.Add(boardCondition);
            DropdownsValues.Add(boardCondition);

            var cardStat = new ActionDropDownInfo_CardStats(cycle);
            DropdownsInfos.Add(cardStat);
            DropdownsValues.Add(cardStat);
        }
        intGetter = new ActionDropDownInfo_Amount(DropdownsInfos, DropdownsValues,this);

        //--- Stats ---
        statGetter = new ActionDropDownInfo_Stat();

        //--- Attribute ---
        attributeGetter = new ActionDropDownInfo_Attribute();

        //--- Type ---
        typeGetter = new ActionDropDownInfo_Type(library);

        Infos = new List<IActionDropdownInfo>()
        {
            intGetter,
            statGetter,
            attributeGetter
        };
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }

    public ActionType GetActionType()
    {
        throw new NotImplementedException();
    }

    public List<IActionDropdownInfo> GetDropDownsInfos()
    {
        return Infos;
    }

    public void UpdateDropdowns(ActionDropDownInfo_Amount actionDropDownInfo_Dropdowns_Int,bool deleteprev, bool addnewsublist, IActionDropdownInfo dropdown)
    {
        if (deleteprev)
        {
            Infos.RemoveAt(Infos.IndexOf(actionDropDownInfo_Dropdowns_Int) + 1);
        }
        if(addnewsublist)
        {
            Infos.Insert(Infos.IndexOf(actionDropDownInfo_Dropdowns_Int) + 1, dropdown);
        }
    }
}