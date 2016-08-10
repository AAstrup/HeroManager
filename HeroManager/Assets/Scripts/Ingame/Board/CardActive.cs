public abstract class CardActive
{
    BoardState.Player owner;
    CardBase Base;

    public virtual void Play()
    {
        throw new System.Exception("This should never be called(CardActive.Play())");
    }
}