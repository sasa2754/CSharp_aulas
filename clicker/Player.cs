namespace Players;

public class Player(string name, long coin = 0)
{
    private string name = name;
    private long coin;

    public string Name { get => name; set => name = value; }
    public long Coin { get => coin; set => coin = value; }
}