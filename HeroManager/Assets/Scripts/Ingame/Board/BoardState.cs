using System;
using System.Collections.Generic;
using System.Diagnostics;

public class BoardState
{
    private InGameController _inGameController;

    public Dictionary<Player, PlayerContent> PlayerContents;
    public enum Player { P1, P2, P3, P4 };

    public BoardState(InGameController IGC)
    {
        _inGameController = IGC;
    }

    public void Init(BattleInfo battleinfo)
    {
        PlayerContents = new Dictionary<Player, PlayerContent>();
        Player tempPlayerCounter = Player.P1;
        do
        {
            PlayerContents.Add(tempPlayerCounter,new PlayerContent(_inGameController,tempPlayerCounter));
            tempPlayerCounter += 1;

        } 
        while (tempPlayerCounter <= _inGameController.Rules._numberOfPlayers);

        //_inGameController.Log("ARE THESE THE SAME? " + battleinfo.p1.GetDeck().GetCards()[0].Equals(battleinfo.p1.GetDeck().GetCards()[1]).ToString());

        /*HERUNDER ER DER KUN SAT OP TIL 2 SPILLERE, DETTE BURDE ÆNDRES PÅ ET TIDSPUNKT - DETTE SKAL GØRES FRA BATTLEINFO OG OPAD AF*/

        var biPlayers = new Dictionary<Player,IPlayer> {{Player.P1,battleinfo.p1},{Player.P2,battleinfo.p2}};

        foreach (Player player in PlayerContents.Keys)
        {
            biPlayers[player].GetDeck().GetCards().ForEach(typ => PlayerContents[player].deck.Add(_inGameController.CardActiveFactory.CreateCardActive(_inGameController, typ, player)));

            PlayerContents[player].hero = new Creature(_inGameController, new CardBase(), player);
            PlayerContents[player].hero.Stats[Stat.Stat2] = _inGameController.Rules._startHealth;

            PlayerContents[player].Origin = biPlayers[player];
        }

    }

}

