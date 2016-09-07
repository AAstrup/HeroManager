using System;
using System.Collections.Generic;
using System.Linq;

public class Candidates
{
    HashSet<CardList> allCardSet;
    public List<Criteria> criterias;

    public Candidates()
    {
        allCardSet = new HashSet<CardList>();
        criterias = new List<Criteria>();
    }

    public void AddCardList(CardList cardList)
    {
        if (!allCardSet.Contains(cardList))
            allCardSet.Add(cardList);
    }


    public enum CardList
    {
        MyHand,             OpHand,
        MyDeck,             OpDeck,
        MyBoard,            OpBoard,
        MyGraveyard,        OpGraveyard,
        MyEquippedWeapon,   OpEquippedWeapon,
        MyUsedCards,        OpUsedCards
    }

    private BoardState.Player OtherPlayer(BoardState.Player me)
    {
        if (me == BoardState.Player.P1)
            return BoardState.Player.P2;
        else
            return BoardState.Player.P1;
    }

    public List<CardActive> GetCandidates(BoardState boardState, BoardState.Player player)
    {
        var meContent = boardState.PlayerContents[player];
        var opContent = boardState.PlayerContents[OtherPlayer(player)];
        List <CardActive> toReturn = new List<CardActive>();

        if (allCardSet.Contains(CardList.MyHand))
            toReturn.AddRange(meContent.hand);
        if (allCardSet.Contains(CardList.OpHand))
            toReturn.AddRange(opContent.hand);

        if (allCardSet.Contains(CardList.MyDeck))
            toReturn.AddRange(meContent.deck);
        if (allCardSet.Contains(CardList.OpDeck))
            toReturn.AddRange(opContent.deck);

        if (allCardSet.Contains(CardList.MyBoard))
            toReturn.AddRange(meContent.board.Cast<CardActive>());
        if (allCardSet.Contains(CardList.OpBoard))
            toReturn.AddRange(opContent.board.Cast<CardActive>());

        if (allCardSet.Contains(CardList.MyGraveyard))
            toReturn.AddRange(meContent.graveyard.Cast<CardActive>());
        if (allCardSet.Contains(CardList.OpGraveyard))
            toReturn.AddRange(opContent.graveyard.Cast<CardActive>());

        if (allCardSet.Contains(CardList.MyEquippedWeapon))
            toReturn.AddRange(meContent.equipWeapons);
        if (allCardSet.Contains(CardList.OpEquippedWeapon))
            toReturn.AddRange(opContent.equipWeapons);

        if (allCardSet.Contains(CardList.MyUsedCards))
            toReturn.AddRange(meContent.usedCards);
        if (allCardSet.Contains(CardList.OpUsedCards))
            toReturn.AddRange(opContent.usedCards);

        return toReturn;
    }
}