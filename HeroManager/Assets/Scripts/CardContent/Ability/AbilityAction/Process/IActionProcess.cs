using System.Collections.Generic;

public interface IActionProcess
{
    void Execute();
    List<IActionDropdownInfo> GetDropDownsInfos();
    ActionType GetActionType();
    void UpdateDropdowns(ActionDropDownInfo_Amount actionDropDownInfo_Dropdowns_Int,bool deleteprev, bool addnewsublist, IActionDropdownInfo dropdown);
}
public enum ActionType
{
    DrawCards,
    Effects,
    ChangeType,
    Summon,
    GiveAttribute,
    Silience,
    Kill
}