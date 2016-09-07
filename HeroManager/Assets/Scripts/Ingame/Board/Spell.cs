public class Spell : CardActive
{
    public Spell(InGameController igc, CardBase cardbase, BoardState.Player owner)
    {
        BaseInit(igc,cardbase,owner);
    }
}