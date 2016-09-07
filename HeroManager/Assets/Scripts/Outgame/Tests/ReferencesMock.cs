using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ReferencesMock : IReferences
{
    public DivisionHandler _divHandler;
    public MM_PlayerHandler _playerHandler;
    public DayHandler _dayHandler;
    public ReferencesMock(References references,DivisionHandler divHandler, MM_PlayerHandler playerHandler,DayHandler dayHandler,List<int> days)
    {
        _divHandler = divHandler;
        _playerHandler = playerHandler;
        _dayHandler = dayHandler;

        _playerHandler.Initialize(new DeckFactoryMock());
        divHandler.Initialize(this, _playerHandler.GetPlayers(), days);
        _dayHandler.Initialize(this,references);
    }

    public void Update()
    {
        _dayHandler.Update();
    }

    public void EndSeason()
    {
        _divHandler.EndSeason();
    }

    public List<Division> GetDivisions()
    {
        return _divHandler.GetDivisions();
    }

    public IPlayer GetHumanPlayer()
    {
        return _playerHandler.GetHumanPlayer();
    }

    public void Initialize()
    {
    }

    public void Print(string v)
    {
    }

    public void Initialize(IUnityAdapter adapter)
    {
        throw new NotImplementedException();
    }
}
