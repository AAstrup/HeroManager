using UnityEngine;
using System.Collections;
using System.Linq;


public class RulesHandler
{

    private InGameController _inGameController;

    public RulesHandler(InGameController IGC)
    {
        _inGameController = IGC;
    }

    public void Setup()
    {
        _inGameController.BoardState.PlayerContents.Keys.ToList().ForEach(typ => _inGameController._inGameHandler._IGPlayerHandler.Draw(typ,_inGameController.Rules._startCards));
    }

    public void HandleRules(Rules rules,int turn,BoardState.Player player)
    {
        rules._ruleActions.ForEach(typ =>
        {
            typ.Delay -= 1;
            if (typ.Delay == 0)
            {
                HandleAct(typ,player);

                if (typ.RepeatDelay != 0)
                {
                    typ.Delay = typ.RepeatDelay;
                }
            }
        });
    }

    public void HandleEmptyDraw(Rules rules,BoardState.Player player)
    {
        _inGameController.BoardState.PlayerContents[player].EmptyDrawNo += 1;
        rules._emptyDrawActions.ForEach(typ =>
        {
            typ.Amount = _inGameController.BoardState.PlayerContents[player].EmptyDrawNo;
            HandleAct(typ,player);
        });
    }

    private void HandleAct(RuleAction action, BoardState.Player player)
    {
        //for (int i = 0; i < action.Amount; i++)
        //{
            switch (action.Type)
            {
                case RuleActionType.Draw:
                {
                    _inGameController._inGameHandler._IGPlayerHandler.Draw(player,action.Amount);
                    break;
                }
                case RuleActionType.Discard:
                {
                    _inGameController._inGameHandler._IGPlayerHandler.DiscardRandom(player,action.Amount);
                    break;
                }
                case RuleActionType.Heal:
                {
                    _inGameController._inGameHandler._IGUnitHandler.Heal(_inGameController.BoardState.PlayerContents[player].hero,action.Amount);
                    break;
                }
                case RuleActionType.Damage:
                {
                    _inGameController._inGameHandler._IGUnitHandler.Damage(_inGameController.BoardState.PlayerContents[player].hero, action.Amount);
                    break;
                }
                case RuleActionType.OfferCrystal:
                {
                    _inGameController._inGameHandler._IGPlayerHandler.OfferCrystal(player,action.Amount);
                    break;
                }
            }
        //}
    }

}
