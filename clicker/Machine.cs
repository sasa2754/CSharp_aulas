namespace Machines;

public class Machine(string name, decimal price, decimal fees) {
    private string name = name;
    private decimal price = price;

    private decimal fees = fees;

    public string Name { get => name; set => name = value; }
    public decimal Price { get => price; set => price = value; }
    public decimal Fees { get => fees; set => fees = value; }
}