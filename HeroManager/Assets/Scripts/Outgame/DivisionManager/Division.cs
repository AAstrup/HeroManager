using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Division {
    IBattle _strategy;
    List<IPlayer> _players;
    int _tournaments;
    bool finished;
    public List<ITournament> tournaments;
    public int currentTournamentNr = 0;
    private int _divisionNr;

    public Division(IBattle strategy,List<IPlayer> players,int tournaments,int divisionNr)
    {
        _strategy = strategy;
        _players = players;
        _tournaments = tournaments;
        _divisionNr = divisionNr;
    }

    public IPlayer GetWinner() {
        IPlayer toReturn = null;
        int index = _players.Count - 1;
        while (toReturn == null)
        {
            if (_players[index].JustSwitchedDivision())
                index--;
            else
                toReturn = _players[index];
        }
        return _players[index];
    }
    public IPlayer GetLoser() {
        IPlayer toReturn = null;
        int index = 0;
        while (toReturn == null)
        {
            if (_players[index].JustSwitchedDivision())
                index++;
            else
                toReturn = _players[index];
        }
        return _players[index];
    }

    public void RemovePlayer(IPlayer player)
    {
        _players.Remove(player);
    }

    internal int GetTournamentsAmount()
    {
        return _tournaments;
    }

    public void AddPlayer(IPlayer player)
    {
        _players.Add(player);
        _players = _players.OrderBy(x => x.GetPoints()).ToList();
    }

    internal void ResetScores()
    {
        foreach (var p in _players)
        {
            p.ResetScore();
        }
    }

    public void SetFinished(bool value)
    {
        finished = value;
    }

    public int GetDivisionNr()
    {
        return _divisionNr;
    }

    public bool IsFinished()
    {
        return finished;
    }

    public int GetPlayersInDivision() { return _players.Count; }

    public List<IPlayer> GetPlayers() { return _players; }

    public IPlayer FindWinner(IPlayer player1, IPlayer player2)
    {
        return _strategy.FindWinner(player1, player2);
    }

    internal void Victory(IPlayer win)
    {
        win.IncreasePoints(1);
        _players = _players.OrderBy(x => x.GetPoints()).ToList();
    }
}
