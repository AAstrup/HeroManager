using System;

public class Ability
{
    Condition _condition;
    IAction _action;

    public Ability(Condition condition,IAction action)
    {
        _condition = condition;
        _action = action;
    }
    public string Explained()
    {
        return _condition.Explained() + _action.Explained();
    }
}