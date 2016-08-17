using System;
using System.Collections;
using UnityEngine;

public class BattleReal : IBattle
{
    public void FindWinner(BattleInfo battleInfo)
    {
        Debug.Log("Battle start in div " + battleInfo.p1.GetDivision().GetDivisionNr());
        if (!battleInfo.p1.IsHuman() && !battleInfo.p2.IsHuman())
        {
            battleInfo.WinnerFound(battleInfo.p1);
            Debug.Log("Battle AI ended!");
        }
        else
        {
            //Debug.Log("Battle Player start here (Not ENDED)!");
            //Kristoffer skriver kode her
            
        }
    }

}
