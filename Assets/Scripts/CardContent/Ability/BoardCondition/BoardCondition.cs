using System.Collections.Generic;

public class BoardCondition
{
    ConditionContainer _conditionContainer;
    Comparison _comp;
    Candidates _candidates;

    public BoardCondition(ConditionContainer conditionContainer, Comparison comp,Candidates candidates)
    {
        _candidates = candidates;
        _conditionContainer = conditionContainer;
        _comp = comp;
        if (conditionContainer._condition != Condition.Number)
            if (_comp != Comparison.None)
                throw new System.Exception("A board condition cannot have a comparison if the condition isn't a number!");
    }

    public enum Condition
    {
        None,
        Exist,
        DoesntExist,
        Number
    }

    public BoardConditionResult BoardConditionTrue(BoardState boardState, BoardState.Player player)
    {
        var candidates = _candidates.GetCandidates(boardState, player);
        return new BoardConditionResult(candidates, BoardConditionBoolCheck(candidates));
    }

    public class BoardConditionResult{
        public List<CardActive> _listCard;
        public bool _boardConditionIsTrue;
        public BoardConditionResult(List<CardActive> listListCard,bool boardCondition)
        {
            _listCard = listListCard;
            _boardConditionIsTrue = boardCondition;
        }
    }
    
    private bool BoardConditionBoolCheck(List<CardActive> candidates)
    {
        int totalElements = candidates.Count;

        if (_conditionContainer._condition == Condition.None)
            return true;
        else if (_conditionContainer._condition == Condition.Exist)
        {
            if (totalElements > 0)
                return true;
        }
        else if (_conditionContainer._condition == Condition.DoesntExist)
        {
            if (totalElements == 0)
                return true;
        }
        else if (_conditionContainer._condition == Condition.Number)
        {
            if (totalElements > _conditionContainer._number && _comp == Comparison.Greater)
                return true;
            else if (totalElements < _conditionContainer._number && _comp == Comparison.Less)
                return true;
            else if (totalElements == _conditionContainer._number && _comp == Comparison.Equal)
                return true;
            else if (totalElements != _conditionContainer._number && _comp == Comparison.Different)
                return true;
        }
        return false;
    }

    public class ConditionContainer
    {
        public Condition _condition;
        public int _number;
        public ConditionContainer(Condition condition, int number)
        {
            _condition = condition;
            _number = number;
        }
    }

    public enum Comparison
    {
        None,
        Equal,
        Different,
        Less,
        Greater
    }
}