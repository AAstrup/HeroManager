using System.Linq;
using UnityEngine;
using System.Collections;

public class IGPlayerHandler
{
    private InGameController _inGameController;

    public IGPlayerHandler(InGameController IGC)
    {
        _inGameController = IGC;
    }

    public void Draw(BoardState.Player player)
    {
        /*Check if empty draw*/
        if (_inGameController.BoardState.PlayerContents[player].deck.Count <= 0)
        {
            _inGameController._rulesHandler.HandleEmptyDraw(_inGameController.Rules,player);
        }
        else
        {
            /*Pull out of deck*/
            CardActive cardDraw = _inGameController.BoardState.PlayerContents[player].deck[0];
            _inGameController.BoardState.PlayerContents[player].deck.RemoveAt(0);

            /*Draw or discard*/
            if (_inGameController.BoardState.PlayerContents[player].hand.Count < _inGameController.Rules._handsize)
            {
                _inGameController.BoardState.PlayerContents[player].hand.Add(
                    cardDraw);
            }
            else
            {
                Discard(player, cardDraw);
            }

            _inGameController.Log("CardDraw ID: " + cardDraw.ID);
        }
    }
    public void Draw(BoardState.Player player, int amount)
    {
        for(int i=0;i<amount;i++){Draw(player);}
    }

    public void AddCardToHand(BoardState.Player player, CardBase cardBase)
    {
        
    }

    public void Discard(BoardState.Player player,CardActive card)
    {

        var temp = _inGameController.BoardState.PlayerContents[player].hand.Find(typ => typ.ID == card.ID);
        if (temp != null)
        {
            Debug.Log("Discarded card exsists in hand = " + temp.ID + " vs " + card.ID);
            _inGameController.BoardState.PlayerContents[player].hand.Remove(card);
        }
        _inGameController.BoardState.PlayerContents[player].discards.Add(card);
    }
    public void DiscardRandom(BoardState.Player player,int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (_inGameController.BoardState.PlayerContents[player].hand.Count > 0)
            {
                int index = Random.RandomRange(0, _inGameController.BoardState.PlayerContents[player].hand.Count);
                Discard(player, _inGameController.BoardState.PlayerContents[player].hand[index]);
            }
        }
    }

    public void OfferCrystal(BoardState.Player player,int amount)
    {
        _inGameController.BoardState.PlayerContents[player].GemPicksPending += amount;
        if (_inGameController.BoardState.PlayerContents[player].GemColorsUsed.Count == 1) //Instantly add the gem, if the player can only pick from 1 color.
        {
            for (int i = 0; i < _inGameController.BoardState.PlayerContents[player].GemPicksPending; i++)
            {
                AddCrystal(player, _inGameController.BoardState.PlayerContents[player].GemColorsUsed[0],true);
            }
        }
    }

    public void AddCrystal(BoardState.Player player, CardColor color,bool instantlyUsable)
    {
        _inGameController.BoardState.PlayerContents[player].ManaGems.Add(new ManaGem(color,instantlyUsable));
        _inGameController.BoardState.PlayerContents[player].GemPicksPending -= 1;
    }

    public void DestroyCrystal(BoardState.Player player, CardColor color)
    {

    }

}
