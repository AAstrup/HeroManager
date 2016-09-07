﻿using UnityEngine.UI;

public class TurnHandler {

    private InGameController _IGController;

    public void Init(InGameController IGC)
    {
        _IGController = IGC;
    }

    public void EndTurn()
    {
        _IGController.PlayerEndTurn();
    }

    public void Decide(int listno, int targetno,TurnController controller)
    {
        switch (controller.GetMode())
        {
            case TurnMode.GemSelect:
            {
                if (targetno < controller._playerContent.GemColorsUsed.Count)
                {
                    _IGController._inGameHandler._IGPlayerHandler.AddCrystal(controller._playerContent._player, controller._playerContent.GemColorsUsed[targetno],true);

                    if (controller._playerContent.GemPicksPending == 0)
                    {
                         controller.SetMode(TurnMode.Play);
                    }
                }

                break;
            }
            case TurnMode.Play:
            {
                switch (listno)
                {
                    case 0:
                        controller._playerContent.hand[targetno].Play();
                        break;
                    case 1:
                        controller.SelectAttacker(controller._playerContent.board[targetno]);
                        break;
                }
                break;
            }
        }
    }

}
