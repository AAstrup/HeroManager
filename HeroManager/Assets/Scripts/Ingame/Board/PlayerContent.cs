using System.Collections.Generic;

public class PlayerContent
{
    public List<CardActive> hand;
    public List<CardActive> deck;
    public List<CardActive> board;
    public List<CardActive> graveyard;
    public List<CardActive> equipWeapons; //Mby dualwield? So far, just use [0]
    public List<CardActive> usedCards; //All cards (including units) who used Play();
    public CardActive hero;
    public int manaCrystals;
    public int manaCrystalsCurrent;
}