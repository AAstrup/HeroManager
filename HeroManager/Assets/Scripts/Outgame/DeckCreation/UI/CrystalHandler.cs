using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class CrystalHandler 
{
    public CrystalTypeDropdown dropType;
    public CrystalPercentageAmountDropdown dropAmount;

    public CrystalHandler(Dropdown[] dropdown,bool isFirst)
    {
        dropType = new CrystalTypeDropdown(dropdown[0]);
        dropAmount = new CrystalPercentageAmountDropdown(dropdown[1],isFirst);
    }

    public void SetChilds(CrystalHandler handler)
    {
        dropAmount.SetChild(handler.dropAmount);
        dropType.SetChild(handler.dropType);
    }
}