using static NewSystem.ManageGame;
using static NewSystem.NewConsole;
using Players;

Player player;


Print("Digite seu nome: ");

var name = Console.ReadLine();

while (true) {

    if (!string.IsNullOrWhiteSpace(name)) {
        player = new(name);
        break;
    } else {
        Print("Por favor, insira seu nome: ");
        name = Console.ReadLine();
    }
}


Print(Options('M', player));

while (true) {
    var key = ReadKey();

    Console.Clear();

    if (key == 'S') {
        Print("Volte Sempre!");
        break;
    }

    Print(Options(key, player));
    
}