using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DivisionHandler {

    DivisionFactory divFactory;
    List<Division> divisions;
    IReferences _Ref;

    public delegate void DivisionAction(Division div);
    public static event DivisionAction OnNewSeason;

    public DivisionHandler()
    {
    }


    public void EndSeason()
    {
        for (int i = 0; i < (divisions.Count - 1); i++)
        {
            var playerWinner = divisions[i].GetWinner();
            var playerLoser = divisions[i + 1].GetLoser();

            playerWinner.ResetScore();
            playerLoser.ResetScore();

            divisions[i].RemovePlayer(playerWinner);
            divisions[i + 1].RemovePlayer(playerLoser);

            divisions[i + 1].AddPlayer(playerWinner);
            divisions[i].AddPlayer(playerLoser);

            playerWinner.SetDivision(divisions[i + 1]);
            playerLoser.SetDivision(divisions[i]);
        }

        foreach (var div in divisions)
        {
            div.ResetScores();
            div.SetFinished(false);
        }
        
        if(OnNewSeason != null)
            OnNewSeason(_Ref.GetHumanPlayer().GetDivision());//Debug here
    }

    public void Initialize(IReferences Ref, List<IPlayer> players, List<int> days)
    {
        _Ref = Ref;
        divFactory = new DivisionFactory();
        divisions = divFactory.CreateDivisions(players, days);
    }

    public List<Division> GetDivisions()
    {
        return divisions;
    }
}
