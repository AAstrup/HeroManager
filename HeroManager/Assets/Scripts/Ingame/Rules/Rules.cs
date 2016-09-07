using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Rules
{

    public BoardState.Player _numberOfPlayers;
    public List<RuleAction> _ruleActions;
    public int _handsize;
    public int _startHealth;
    public int _startCards;
    public Dictionary<CardColor, int> _maxCrystals;
    public List<RuleAction> _emptyDrawActions; 

    public Rules()
    {
        _numberOfPlayers  = BoardState.Player.P2;

        _ruleActions = new List<RuleAction>()
        {
            new RuleAction(RuleActionType.Draw, 1,1,1),
            new RuleAction(RuleActionType.OfferCrystal, 1,1,1)
        };
        _emptyDrawActions = new List<RuleAction>()
        {
            new RuleAction(RuleActionType.Damage)
        };

        _handsize = 10;
        _startHealth = 30;
        _startCards = 4;
        _maxCrystals = new Dictionary<CardColor, int>()
        {
            {CardColor.Black, 10},
            {CardColor.Blue, 10},
            {CardColor.Green, 10},
            {CardColor.Yellow, 10},
            {CardColor.White, 10},
            {CardColor.Red, 10}
        };
    }

    public Rules(List<RuleAction> ruleactions,int handsize,int starthealth,int startcards,Dictionary<CardColor, int> maxCrystals)
    {
        _ruleActions = ruleactions;
        _handsize = handsize;
        _startHealth = starthealth;
        _startCards = startcards;
        _maxCrystals = maxCrystals;
    }

}
