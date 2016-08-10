using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DayHandler
{
    IReferences _Ref;
    TournamentFactory tournamentfactory;
    int Day = 0;

    public delegate void NextPlayerDayAction(Division div);
    public event NextPlayerDayAction OnNewPlayerDay;

    public void Initialize(IReferences Ref)
    {
        _Ref = Ref;
        tournamentfactory = new TournamentFactory();
        List<Division> divs = _Ref.GetDivisions();
        for (int i = 0; i < Ref.GetDivisions().Count; i++)
        {
            divs[i].tournaments = new List<ITournament>();
        }
        NewSeason();
        MM_PlayerInputs.OnJump += NextDayInput;
    }

    public void NextDayInput()
    {
        NextDay();

        while (_Ref.GetHumanPlayer().GetDivision().IsFinished())
        {
            NextDay();
        } 
    }

    public void Update()
    {

    }

    public void NextDay()
    {
        Day++;
        List<Division> divs = _Ref.GetDivisions();
        for (int i = 0; i < divs.Count; i++)
        {
            ITournament currentTournament = divs[i].tournaments[divs[i].currentTournamentNr];
            if (currentTournament.IsDone())
            {
                NextTournament(divs[i]);
            }
            else
            {
                currentTournament.IncreaseDay();
                if (currentTournament.IsDone())
                {
                    divs[i].SetFinished(true);
                    CheckMonthEnd();
                }
            }
        }
        _Ref.Print("Day " + Day.ToString() + ", players at " + _Ref.GetHumanPlayer().GetDivision().GetDivisionNr());
        if (OnNewPlayerDay != null)
            OnNewPlayerDay(_Ref.GetHumanPlayer().GetDivision());
    }

    private void NextTournament(Division div)
    {
        div.currentTournamentNr++;
        ITournament currentTournament = div.tournaments[div.currentTournamentNr];
        currentTournament.IncreaseDay();
    }

    private List<ITournament> GenerateTournaments(int amount,Division div)
    {
        List<ITournament> toReturn = new List<ITournament>();
        for (int i = 0; i < amount; i++)
        {
            toReturn.Add( tournamentfactory.CreateTournament(div));
        }
        return toReturn;
    }

    void CheckMonthEnd()
    {
        List<Division> divs = _Ref.GetDivisions();
        foreach (var div in divs)
        {
            if (!div.IsFinished())
                return;
        }
        _Ref.EndSeason();
    }

    public void MonthStart()
    {
        NewSeason();
    }
    public void NewSeason()
    {
        Day = 0;
        List<Division> divs = _Ref.GetDivisions();
        for (int i = 0; i < divs.Count; i++)
        {
            divs[i].tournaments = GenerateTournaments(divs[i].GetTournamentsAmount(), divs[i]);
            divs[i].currentTournamentNr = 0;
        }
        
    }
}
