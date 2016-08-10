﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class References : IReferences
{
    public LibrariesContainer librariesContainer;
    public DeckFactory factory;
    public LeagueHandler leagueHandler;
    
    public void Initialize()
    {
        librariesContainer = new LibrariesContainer();
        librariesContainer.Initialize();

        factory = new DeckFactory();
        factory.Initialize();

        leagueHandler = new LeagueHandler();
        leagueHandler.Initialize(factory,this);
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