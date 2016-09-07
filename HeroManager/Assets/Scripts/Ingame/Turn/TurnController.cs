using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class TurnController
{

    public InGameController _IGController;
    public PlayerContent _playerContent;

    public CardActive SelectedCard;

    private TurnMode _mode;

    public void Init(InGameController IGC,PlayerContent playerContent)
    {
        _IGController = IGC;
        _mode = TurnMode.Play;
        _playerContent = playerContent;
    }

    public void SetMode(TurnMode mode)
    {
        _mode = mode;
    }
    public TurnMode GetMode()
    {
        return _mode;
    }
    public void EndTurn()
    {
        _IGController.TurnHandler.EndTurn();
    }
    public virtual void Update()
    {

    }

    public void Decide(int listno, int targetno)
    {
        _IGController.TurnHandler.Decide(listno, targetno, this);
    }

    public void SelectAttacker(Creature attacker)
    {
        SelectedCard = attacker;
        _mode = TurnMode.BoardSelect;
    }

}

public enum TurnMode
{
    Play,
    BoardSelect,
    GemSelect
}