using UnityEngine;
using System.Collections;

public class RuleAction
{

    public int Draws;
    public int Discards;
    public int Crystals;
    public int Damage;
    public int Heal;
    public int Delay;
    public int RepeatDelay;

    public RuleAction(int delay,int repeatdelay)
    {
        Delay = delay;
        RepeatDelay = repeatdelay;
    }

}
