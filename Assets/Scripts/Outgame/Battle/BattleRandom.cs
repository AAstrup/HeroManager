﻿using System;
using System.Collections;

public class BattleRandom : IBattle
{
    public void FindWinner(BattleInfo battleInfo)
    {
        throw new NotImplementedException();
    }

    public void FindWinner(IPlayer player1, IPlayer player2)
    {
        /*
        To be fixed

        if (player1.IsHuman())
            return player1;
        else if (player2.IsHuman())
            return player2;
        else
            return FindWinnerAI(player1, player2);*/
    }

    /*private IPlayer FindWinnerAI(IPlayer player1,IPlayer player2)
    {
        Random random = new Random();
        int randomNumber = random.Next(0, 100);
        if (randomNumber < 50)
            return player1;
        else
            return player2;
    }*/
}