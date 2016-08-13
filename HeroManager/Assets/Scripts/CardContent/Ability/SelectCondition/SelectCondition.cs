using System;
using System.Collections.Generic;

public class SelectCondition
{
    public Target _target;
    public int _randomTargets;

    public List<CardActive> targets;

    public SelectCondition(Target target,int randomTargets = 0)
    {
        _target = target;
        _randomTargets = randomTargets;
    }

    public void ChooseTarget(BoardState boardState,BoardCondition.BoardConditionResult boardConditionResult, AbilityAction abilityAction)
    {
        if (_target == Target.All)
        {
            targets = boardConditionResult._listCard;
            abilityAction.Trigger(boardConditionResult._listCard, boardState);
        }
        else if (_target == Target.Random)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, boardConditionResult._listCard.Count);
            var finalList = new List<CardActive>() { boardConditionResult._listCard[randomNumber] };
            targets = finalList;
            abilityAction.Trigger(finalList, boardState);
        }
        else if(_target == Target.Choose)
        {
            //targets = den valgte unit
            throw new NotImplementedException("Selection tool should be called, with abilityAction, such that it can call abilityAction.Trigger()");
        }
    }

    public enum Target { All, Random, Choose }

}