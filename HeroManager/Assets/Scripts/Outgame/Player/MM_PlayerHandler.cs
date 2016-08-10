using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MM_PlayerHandler
{
    List<IPlayer> players;
    IPlayer humanPlayer;
    public void Initialize(IDeckFactory factory)
    {
        players = new List<IPlayer>();

        //player 1
        humanPlayer = new HumanPlayer("Player");
        humanPlayer.SetDeck(factory.GeneratePlayerStartDeck());
        players.Add(humanPlayer);

        //AI test
        for (int i = 1; i < 8; i++)
        {
            var ai = new AIPlayer("Bob "+ i, AIMoneyBehavior.Saver, AISetupStrategy.Agressive);
            ai.SetDeck(factory.GenerateAIDeck(factory));
            players.Add(ai);
        }
    }

    public List<IPlayer> GetPlayers()
    {
        return players;
    }

    internal IPlayer GetHumanPlayer()
    {
        return humanPlayer;
    }

    //public IPlayer GetHumanPlayer()
    //{
    //    return humanPlayer;
    //}
}
