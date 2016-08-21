using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class References : IReferences
{
    public LibrariesContainer librariesContainer;
    public DeckFactory factory;
    public LeagueHandler leagueHandler;
    public IUnityAdapter _adapter;


    public void Initialize(IUnityAdapter adapter)
    {
        _adapter = adapter;

        librariesContainer = new LibrariesContainer();
        librariesContainer.Initialize();

        factory = new DeckFactory();
        factory.Initialize();

        leagueHandler = new LeagueHandler();
        leagueHandler.Initialize(factory,this);
    }

    public GameObject GetCardCreationUI()
    {
        return _adapter.InstatiateUI(librariesContainer.prefabLibrary.Prefabs["CardCreationUIPrefab"]);
    }

    public void Update()
    {
        leagueHandler.dayHandler.Update();
    }

    public void EndSeason()
    {
        leagueHandler.divHandler.EndSeason();
    }

    public List<Division> GetDivisions()
    {
        return leagueHandler.divHandler.GetDivisions();
    }

    public IPlayer GetHumanPlayer()
    {
        return leagueHandler.playerHandler.GetHumanPlayer();
    }

    public void Print(string v)
    {
        Debug.Log(v);
    }
}
