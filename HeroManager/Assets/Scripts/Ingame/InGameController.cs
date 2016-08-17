using UnityEngine;
using System.Collections;

public class InGameController
{

    private BattleInfo _battleinfo;
    private Rules rules;
    private int turn;
    private int playerturn;

	void Init (BattleInfo battleinfo)
	{
	    _battleinfo = battleinfo;
	    turn = 0;
	    playerturn = 0;

        

	}
	
	void Update () {
	
	}
}
