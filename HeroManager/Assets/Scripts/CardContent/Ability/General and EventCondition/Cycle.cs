using System;

public class Cycle
{
    BoardCondition boardCondition;
    SelectCondition selectCondition;
    AbilityAction abilityAction;
    public int _no;

    public Cycle(int no)
    {
        _no = no;
    }
    
    public int GetSelectConditionSize()
    {
        return selectCondition.targets.Count;
    }

    public void TriggerCycle(BoardState boardState, BoardState.Player player)
    {
        var boardConditionResult = boardCondition.BoardConditionTrue(boardState, player);
        if (boardConditionResult._boardConditionIsTrue)
        {
            selectCondition.ChooseTarget(boardState,boardConditionResult, abilityAction);
        }
    }
}
