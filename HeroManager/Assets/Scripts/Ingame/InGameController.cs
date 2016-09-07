using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class InGameController
{
    private BattleInfo _battleinfo;
    public Rules Rules;
    private int turn;
    private BoardState.Player playerinturn;
    public TurnHandler TurnHandler;
    public InGameHandler _inGameHandler;
    public RulesHandler _rulesHandler;
    public BoardState BoardState;
    public IDGenerator IdGenerator;
    public CardActiveFactory CardActiveFactory;

    public bool HandleTurn;

	public void Init (BattleInfo battleinfo)
	{
        //Enum.GetValues(typeof(Stat)).Cast<Stat>().ToList().ForEach(typ => Debug.Log(typ));

        CardActiveFactory = new CardActiveFactory();

        IdGenerator = new IDGenerator();
	    IdGenerator.Init(this);

        _inGameHandler = new InGameHandler();
	    _inGameHandler.Init(this);

	    _battleinfo = battleinfo;
	    turn = 0;
        playerinturn = 0;

        Rules = new Rules();
        _rulesHandler = new RulesHandler(this);

        TurnHandler = new TurnHandler();
        TurnHandler.Init(this);

        BoardState = new BoardState(this);
	    BoardState.Init(_battleinfo);

        _rulesHandler.Setup();

        NewTurn();

        //BoardState.PlayerContents[BoardState.Player.P1].deck.ForEach(typ => Debug.Log(typ.Base._name));

	    HandleTurn = true;

        //Debug.Log(BoardState.PlayerContents[BoardState.Player.P1].deck[0].Equals(BoardState.PlayerContents[BoardState.Player.P1].deck[1]));
	}

    public void Update()
    {

        if (HandleTurn)
        {
            BoardState.PlayerContents[playerinturn].Controller.Update();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(BoardState.PlayerContents[BoardState.Player.P1].deck.Count);
            Debug.Log(BoardState.PlayerContents[BoardState.Player.P2].deck.Count);
        }

        BoardState.PlayerContents.Keys.ToList().ForEach(PlayerDebugInfo);  

	}

    public void NewTurn()
    {
        playerinturn = BoardState.Player.P1;
        turn += 1;

        PlayerNewTurn();

    }

    public void PlayerNewTurn()
    {
        BoardState.PlayerContents[playerinturn].Controller.SetMode(TurnMode.Play);
        _rulesHandler.HandleRules(Rules, turn, playerinturn);
    }

    public void PlayerEndTurn()
    {
        if (playerinturn == Rules._numberOfPlayers)
        {
            NewTurn();
        }
        else
        {
            playerinturn += 1;
            PlayerNewTurn();
        }
    }

    public void PlayerDebugInfo(BoardState.Player p)
    {
        Debug.Log(p + " | Hand size:" + BoardState.PlayerContents[p].hand.Count.ToString() + " | Deck size: " + BoardState.PlayerContents[p].deck.Count + " | Health: " + BoardState.PlayerContents[p].hero.Stats[Stat.Stat2].ToString());

        //string t = "";
        //BoardState.PlayerContents[playerinturn].hand.ForEach(typ => t += typ.ID.ToString() + " ");
        //Debug.Log(t);
    }

    public void Log(string s){Debug.Log(s);}

}
