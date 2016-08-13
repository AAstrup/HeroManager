using UnityEngine;
using System.Collections.Generic;

public class DivisionFactory {

    public List<Division> CreateDivisions(List<IPlayer> players,List<int> days)
    {
        List<Division> toReturn = new List<Division>();

        if (days.Count != 3)
            throw new System.Exception("Bad input, the tournament days should fit with the amount of divisions");
        toReturn.Add(new Division(new BattleReal(), RecreatePartOfList(0, 2, players), days[0],1));
        toReturn.Add(new Division(new BattleReal(), RecreatePartOfList(2, 2, players), days[1],2));
        toReturn.Add(new Division(new BattleReal(), RecreatePartOfList(4, 4, players), days[2],3));
        if (players.Count > 8)
            throw new System.Exception("Bad input");

        //Setup players to know their division as well
        foreach (var div in toReturn)
        {
            foreach (var player in div.GetPlayers())
            {
                player.SetDivision(div);
            }
        }

        return toReturn;
    }

    List<IPlayer> RecreatePartOfList(int startIndex,int amount, List<IPlayer> list)
    {
        var toReturn = new List<IPlayer>();
        for (int i = startIndex; i < (startIndex + amount); i++)
        {
            toReturn.Add(list[i]);
        }
        return toReturn;
    }

    /*public List<Division> CreateDivisions(List<IPlayer> players)
    {
        List<Division> toReturn = new List<Division>();
        int currentIndex = 0;
        int divisionIndex = 0;
        while(currentIndex < players.Count)
        {
            List<IPlayer> divPlayers = new List<IPlayer>();
            for (int i = currentIndex; i < (currentIndex + startPlayerAmounts + divisionIndex * playerIncreaseAmount); i++)
            {
                divPlayers.Add(players[i]);
            }
            currentIndex += divisionIndex * playerIncreaseAmount;

            toReturn.Add(new Division(new BattleRandom(), divPlayers));
            divisionIndex++;
        }
        return toReturn;
    }*/
}
