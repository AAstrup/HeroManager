using System;
using System.Collections.Generic;

public class LeagueHandler
{
    public DivisionHandler divHandler;
    public MM_PlayerHandler playerHandler;
    public DayHandler dayHandler;
    public void Initialize(IDeckFactory factory,IReferences Ref)
    {

        playerHandler = new MM_PlayerHandler();
        playerHandler.Initialize(factory);

        divHandler = new DivisionHandler();
        divHandler.Initialize(Ref, playerHandler.GetPlayers(), new List<int> { 3, 3, 3 });

        dayHandler = new DayHandler();
        dayHandler.Initialize(Ref);
    }
}