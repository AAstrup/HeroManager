using System.Collections.Generic;

public interface IActionDropdownInfo
{
    void SelectValue(int index);
    bool HasSublist();
    string GetName();
    List<string> GetDropDownInput();
}