namespace Players;

using Machines;

public class Player(string name, List<Machine> machines, decimal coin = 0) {
    private string name = name;
    private decimal coin = coin;

    private List<Machine> machines = machines;

    public string Name { get => name; set => name = value; }
    public decimal Coin { get => coin; set => coin = value; }
    public List<Machine> Machines { get => machines; set => machines = value; }

    public void AddMachine(Machine machine) {
        Machines.Add(machine);
    }
}