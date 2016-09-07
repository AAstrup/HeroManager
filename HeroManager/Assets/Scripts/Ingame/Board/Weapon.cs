public class Weapon : CardActive
{
    public Weapon(InGameController igc, CardBase cardbase, BoardState.Player owner)
    {
        BaseInit(igc,cardbase,owner);
    }
}