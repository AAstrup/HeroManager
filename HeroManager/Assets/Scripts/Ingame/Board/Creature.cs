public class Creature : CardActive
{

    public Creature(InGameController igc, CardBase cardbase, BoardState.Player owner)
    {
        BaseInit(igc,cardbase,owner);
    }
    public override void Play()
    {
        if (Playable())
        {
            base.Play();
            _IGC.BoardState.PlayerContents[_owner].board.Add(this);
            _IGC.BoardState.PlayerContents[_owner].hand.Remove(this);
        }
    }

}