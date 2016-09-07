using System;
using UnityEngine;
using System.Collections;

public class RuleAction
{

    public RuleActionType Type;
    public int Amount;
    public int Delay;
    public int RepeatDelay;

    public RuleAction(RuleActionType type) //Empty draw action rule
    {
        Type = type;
    }

    public RuleAction(RuleActionType type,int amount,int delay,int repeatdelay) //Generic action rule
    {
        Type = type;
        Amount = amount;
        Delay = delay;
        RepeatDelay = repeatdelay;
    }

}

public enum RuleActionType
{
    Draw,
    Discard,
    OfferCrystal,
    Damage,
    Heal,
    GameDraw,
    GameWin,
    GameLose
}
