using UnityEngine.UI;
using System.Collections.Generic;

internal class ManaDropDownsHandler
{
    public List<CrystalHandler> crystalHandlers;
    public CrystalHandler crystalHandler1;
    public CrystalHandler crystalHandler2;
    public CrystalHandler crystalHandler3;

    //This array is a mix of type and amount
    //Type - Amount - Type - Amount - Type - Amount
    public ManaDropDownsHandler(Dropdown[] crystalsDropDowns)
    {
        crystalHandlers = new List<CrystalHandler>();
        crystalHandler1 = new CrystalHandler(new Dropdown[] { crystalsDropDowns[0], crystalsDropDowns[1] },true);
        crystalHandler2 = new CrystalHandler(new Dropdown[] { crystalsDropDowns[2], crystalsDropDowns[3] },false);
        crystalHandler3 = new CrystalHandler(new Dropdown[] { crystalsDropDowns[4], crystalsDropDowns[5] },false);
        crystalHandlers.Add(crystalHandler1); crystalHandlers.Add(crystalHandler2); crystalHandlers.Add(crystalHandler3);

        crystalHandler1.SetChilds(crystalHandler2);
        crystalHandler2.SetChilds(crystalHandler3);

        //Setup
        crystalHandler1.dropAmount.SelectValue(0);
        crystalHandler1.dropType.SelectValue(0);
    }

    public CrystalHandler GetCrystalHandler(int index)
    {
        return crystalHandlers[index];
    }
}