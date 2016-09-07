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

    public bool InGame;
    public InGameController IGController;

    public void Initialize(IUnityAdapter adapter)
    {
        InGame = false;

        _adapter = adapter;

        librariesContainer = new LibrariesContainer();
        librariesContainer.Initialize();

        factory = new DeckFactory();
        factory.Initialize();

        leagueHandler = new LeagueHandler();
        leagueHandler.Initialize(factory,this,this);
    }

    public GameObject GetCardCreationUI()
    {
        return _adapter.InstatiateUI(librariesContainer.prefabLibrary.Prefabs["CardCreationUIPrefab"]);
    }

    public void Update()
    {
        leagueHandler.dayHandler.Update();

        if (InGame)
        {
            IGController.Update();
        }
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

    public void InGameStart(BattleInfo battleinfo)
    {
        InGame = true;
        IGController = new InGameController();
        IGController.Init(battleinfo); 
    }

}
