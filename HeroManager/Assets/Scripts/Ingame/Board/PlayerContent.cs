using System.Collections.Generic;
using UnityEngine.Networking;

public class PlayerContent
{
    public PlayerType Type;

    public BoardState.Player _player;

    public TurnController Controller;
    public IPlayer Origin;

    public List<CardColor> GemColorsUsed;
    public int GemPicksPending;

    public List<CardActive> hand;
    public List<CardActive> deck;
    public List<Creature> board;
    public List<Creature> graveyard;
    public List<CardActive> equipWeapons; //Mby dualwield? So far, just use [0]
    public List<CardActive> usedCards; //All cards (including units) who used Play();
    public List<CardActive> discards; 
    public Creature hero;
    public List<ManaGem> ManaGems;

    public int EmptyDrawNo;

    public PlayerContent(InGameController IGC,BoardState.Player player)
    {
        _player = player;

        hand = new List<CardActive>();
        deck = new List<CardActive>();
        board = new List<Creature>();
        graveyard = new List<Creature>();
        equipWeapons = new List<CardActive>();
        usedCards = new List<CardActive>();
        discards = new List<CardActive>();
        ManaGems = new List<ManaGem>();
        GemPicksPending = 0;
        EmptyDrawNo = 0;
        
        Type = PlayerType.Human;

        CreateController(Type,IGC);

        //TEMP
        GemColorsUsed = new List<CardColor>(){CardColor.Red};
    }

    private void CreateController(PlayerType type, InGameController igc)
    {
        switch (type)
        {
            case PlayerType.Human:
            {
                Controller = new TurnController_Human();
                Controller.Init(igc, this);
                break;
            }
            case PlayerType.AI:
            {
                Controller = new TurnController_AI();
                Controller.Init(igc, this);
                break;
            }
            case PlayerType.Remote: //BØR IKKE HAVE EN CONTROLLER, ELLER OGSÅ EN TURNCONTROLLER_REMOTE
            {
                //Controller = new TurnController_Human();
                //Controller.Init(igc, this);
                break;
            }
        }
    }

}

public enum PlayerType
{
    Human,
    AI,
    Remote
}