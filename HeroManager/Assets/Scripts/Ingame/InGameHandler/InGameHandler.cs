using UnityEngine;
using System.Collections;

public class InGameHandler
{
    private InGameController _inGameController;

    public IGPlayerHandler _IGPlayerHandler;
    public IGUnitHandler _IGUnitHandler;

    public void Init(InGameController IGC)
    {
        _inGameController = IGC;

        _IGPlayerHandler = new IGPlayerHandler(_inGameController);
        _IGUnitHandler = new IGUnitHandler(this);
    }

}
