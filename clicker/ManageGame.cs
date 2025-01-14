namespace NewSystem;

using System.Security;
using static NewSystem.NewConsole;
using Players;
using Machines;

public static class ManageGame {
    public static string Options(System.ConsoleKey key, Player player){
        // Juros que cada máquina causa, começam com 1

        Machine machine1 = new("Máquina simples", 150, 0.1M);
        Machine machine2 = new("Máquina avançada", 500, 0.2M);
        Machine machine3 = new("MÁQUINA SUPER MEGA HIPER INCRÍVEL", 2000, 0.5M);


        if (key == ConsoleKey.M)
            return Menu();
        
        if (key == ConsoleKey.L || key == ConsoleKey.V || key == ConsoleKey.C || key == ConsoleKey.U)
            return Market(machine1, machine2, machine3);

        if (key == ConsoleKey.D1)
            return Machine1(machine1, player);
        
        if (key == ConsoleKey.D2)
            return Machine2(machine2, player);

        if (key == ConsoleKey.D3)
            return Machine3(machine3, player);


        if (key == ConsoleKey.J || key == ConsoleKey.Spacebar)
            return Clicker(player, machine1, machine2, machine3);

        return "Selecione uma das opções!";
    }

    private static string Menu() {
        var screen = "===============================================================================================\n ____                            __          ____    ___                __                      \n/\\  _`\\                         /\\ \\        /\\  _`\\ /\\_ \\    __        /\\ \\\n\\ \\ \\L\\ \\    ___     ____    ___\\ \\ \\___    \\ \\ \\/\\_\\//\\ \\  /\\_\\    ___\\ \\ \\/'\\      __   _ __  \n \\ \\  _ <'  / __`\\  /',__\\  /'___\\ \\  _ `\\   \\ \\ \\/_/_\\ \\ \\ \\/\\ \\  /'___\\ \\ , <    /'__`\\/\\`'__\\\n  \\ \\ \\L\\ \\/\\ \\L\\ \\/\\__, `\\/\\ \\__/\\ \\ \\ \\ \\   \\ \\ \\L\\ \\\\_\\ \\_\\ \\ \\/\\ \\__/\\ \\ \\\\`\\ /\\  __/\\ \\ \\/ \n   \\ \\____/\\ \\____/\\/\\____/\\ \\____\\\\ \\_\\ \\_\\   \\ \\____//\\____\\\\ \\_\\ \\____\\\\ \\_\\ \\_\\ \\____\\\\ \\_\\ \n    \\/___/  \\/___/  \\/___/  \\/____/ \\/_/\\/_/    \\/___/ \\/____/ \\/_/\\/____/ \\/_/\\/_/\\/____/ \\/_/\n===============================================================================================\nJ - Jogar\nL - Loja\nS - Sair\n";
        return screen;
    }

    private static string Market(Machine machine1, Machine machine2, Machine machine3) {
        var screen = $"===============================================================================================\n /'\\_/`\\                 /\\ \\            /\\ \\__   \n/\\      \\     __     _ __\\ \\ \\/'\\      __\\ \\ ,_\\  \n\\ \\ \\__\\ \\  /'__`\\  /\\`'__\\ \\ , <    /'__`\\ \\ \\/  \n \\ \\ \\_/\\ \\/\\ \\L\\.\\_\\ \\ \\/ \\ \\ \\\\`\\ /\\  __/\\ \\ \\_ \n  \\ \\_\\\\ \\_\\ \\__/.\\_\\\\ \\_\\  \\ \\_\\ \\_\\ \\____\\\\ \\__\\\n   \\/_/ \\/_/\\/__/\\/_/ \\/_/   \\/_/\\/_/\\/____/ \\/__/\n===============================================================================================\n1 - {machine1.Name}\n2 - {machine2.Name}\n3 - {machine3.Name}\nM - Voltar para o Menu";
        return screen;
    }

    private static string Machine1(Machine machine, Player player) {
        var screen = $"Preço: {machine.Price:C}\n===============================================================================================\n                          _______\n                         |       |\n                         |_______|   \n                         |       |  \n                         |_______|\n                        /         \\\n                       /___________\\\n                      |   _______   |\n                      |  |       |  |\n                      |  |       |  |\n                      |  |_______|  |\n                      |_____________|\n===============================================================================================\nC - Comprar\nU - Upgrade\nV - Voltar";

        var key = Console.ReadKey();

        buyAndUpgrade(key.Key, player, machine);

        return screen;
    }

    private static string Machine2(Machine machine, Player player) {
        var screen = $"Preço: {machine.Price:C}\n===============================================================================================\n                          _______________\n                         |               |\n                         |  [====O====]  |\n                         |_______________|\n                         |   _________   |\n                         |  |         |  |\n                         |  |   [O]   |  |\n                         |  |_________|  |\n                        /_______________\\\n                       |   _________     |\n                       |  |         |    |\n                       |  |   [O]   |    |\n                       |  |_________|    |\n                       |_________________|\n                      /                   \\\n                     /_____________________\\\n===============================================================================================\nC - Comprar\nU - Upgrade\nV - Voltar";

        var key = Console.ReadKey();


        buyAndUpgrade(key.Key, player, machine);
        
        return screen;
    }

    private static string Machine3(Machine machine, Player player) {
        var screen = $"Preço: {machine.Price:C}\n===============================================================================================\n                          ___________________________________________\n                         /                                           \\\n                        |    _____________________________________    |\n                        |   |                                     |   |\n                        |   |   [========O========]   [===O===]   |   |\n                        |   |                                     |   |\n                        |   |   [O]     [O]       [O]     [O]     |   |\n                        |   |_____________________________________|   |\n                        |                                           |\n                        |    ______     ______     ______     ______  |\n                        |   |      |   |      |   |      |   |      | |\n                        |   |  [O] |   | [O]  |   | [O]  |   |  [O] | |\n                        |   |______|   |______|   |______|   |______| |\n                        |                                           |\n                        \\___________________________________________/\n                         /                                         \\\n                        /___________________________________________\\\n                       |                                             |\n                       |        WARNING: EXTREME POWER AHEAD         |\n                       |_____________________________________________|\n===============================================================================================\nC - Comprar\nU - Upgrade\nV - Voltar";

        var key = Console.ReadKey();

        buyAndUpgrade(key.Key, player, machine);
        
        return screen;
    }

    private static string Clicker(Player player, Machine machine1, Machine machine2, Machine machine3) {
        var screen = "===============================================================================================\n                          ____________________________\n                         /                            \\\n                         |   [       SPACE      ]     |\n                         \\____________________________/\n===============================================================================================\nSPACE - Click\nM - Voltar para o Menu";
        
        var key = Console.ReadKey();


        decimal fees = 1;
        
        if (key.Key == ConsoleKey.Spacebar) {
            if (player.Machines.Count >= 1) {
                for (int i = 0; i < player.Machines.Count; i++) {
                    if (player.Machines[i].Name == machine1.Name) {
                        fees += machine1.Fees;
                    }
                    else if (player.Machines[i].Name == machine2.Name) {
                        fees += machine2.Fees;
                    }
                    else if (player.Machines[i].Name == machine3.Name) {
                        fees += machine3.Fees;
                    }
                }
            }

            player.Coin = (player.Coin += 1) * fees;
            Console.WriteLine($"Quantidade de moedas: {player.Coin:C}");
        }
         
        return screen;
    }






    private static void buyAndUpgrade(ConsoleKey key, Player player, Machine machine) {
        Print("Entrou na função!");
        bool exist = false;

        // Se o usuário quiser comprar uma máquina
        if (key == ConsoleKey.C) {
            // Se ele tiver dinheiro para comprar a máquina
            if (player.Coin >= machine.Price) {
                // Iterando sobre todas as máquinas que a pessoa possui e vendo se ela já tem essa máquina
                for (int i = 0; i < player.Machines.Count; i++) {
                    if (player.Machines[i].Name == machine.Name) {
                        Print("Você já possui essa máquina, faça upgrade para aumentar a produção!");
                        exist = true;
                    } 
                }
                // Se ela não possuir, adiciona a máquina no player e desconta o dinheiro dele
                if (!exist) {
                    player.AddMachine(machine);
                    player.Coin -= machine.Price;
                }
            // Se não tiver dinheiro pra comprar a máquina
            } else {
                Print("Você não tem Moedas o suficiente para realizar essa compra!");
            }


        // Se o usuário quiser dar upgrade em alguma máquina
        } else if (key == ConsoleKey.U) {

            // Se ele tiver dinheiro para comprar a máquina
            if (player.Coin >= machine.Price) {
                // Iterando sobre todas as máquinas que a pessoa possui e vendo se ela já tem essa máquina
                for (int i = 0; i < player.Machines.Count; i++) {
                    if (player.Machines[i].Name == machine.Name) {
                        exist = true;
                        Print("Upgrade feito!");
                    }
                }
                // Se ela possuir, adiciona o upgrade na máquina e desconta o dinheiro dele, se não possuir, da um alerta falando para comprar a máquina primeiro
                if (exist) {
                    machine.Fees += 0.2M;
                    player.Coin -= machine.Price;
                } else {
                    Print("Você não possui essa máquina, compre ela primeiro, para depois fazer upgrade!");
                }

            // Se não tiver dinheiro pra comprar o upgrade
            } else {
                Print("Você não tem Moedas o suficiente para dar upgrade nessa máquina!");
            }
        }
    }
}