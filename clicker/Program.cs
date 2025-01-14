using static NewSystem.ManageGame;
using static NewSystem.NewConsole;
using Players;
using Machines;

Player player;

Print("Digite seu nome: ");

var name = Console.ReadLine();

while (true) {

    if (!string.IsNullOrWhiteSpace(name)) {
        player = new(name, new List<Machine>());
        break;
    } else {
        Print("Por favor, insira seu nome: ");
        name = Console.ReadLine();
    }
}


Print(Options(ConsoleKey.M, player));

while (true) {
    var key = Console.ReadKey();

    Console.Clear();

    if (key.Key == ConsoleKey.S) {
        Print($"Até mais, {player.Name}!");
        break;
    }

    // Printar a quantidade de coins
    Print(Options(key.Key, player));
}