public class BattleInfo
{
    public IPlayer p1;
    public IPlayer p2;
    public IBattle battle;
    public TreeTournament.Block block;
    //public IReferences _reference;
    public BattleInfo(IPlayer P1,IPlayer P2, TreeTournament.Block Block,IBattle Battle)
    {
        p1 = P1;
        p2 = P2;
        battle = Battle;
        block = Block;
    }

    /// <summary>
    /// This is called when a winner is found!
    /// </summary>
    /// <param name="win"></param>
    public void WinnerFound(IPlayer win)
    {
        block.WinnerFound(win);
    }
}