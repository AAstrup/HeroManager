public class Criteria
{
    public int value;
    public Stat stat;
    public Comparison comparison;

    public Criteria()
    {

    }

    public enum Comparison
    {
        Equal,
        Different,
        Less,
        Greater
    }

    
}
