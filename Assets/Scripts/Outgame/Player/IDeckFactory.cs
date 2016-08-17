public interface IDeckFactory
{
    Deck GeneratePlayerStartDeck();
    Deck GenerateAIDeck(IDeckFactory factory);
}