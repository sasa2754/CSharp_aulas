using Soldiers;

var rand = new Random();

// Se for true, o ataque ganhou, se for false, a defesa ganhou
bool War(Soldier defender, Soldier attacker) {
    int countDefender = 0;
    int countAttacker = 0;

    int[] defenderDice = new int[3];
    int[] attackerDice = new int[3];

    while(attacker.CountSoldiers > 1 && defender.CountSoldiers > 0) {

        countAttacker = Math.Min(3, attacker.CountSoldiers - 1);
        countDefender = Math.Min(3, defender.CountSoldiers);

        lock (rand){
            for(int j = 0; j < countAttacker; j++)
                attackerDice[j] = rand.Next(1, 7);
            
            for(int j = 0; j < countDefender; j++)
                defenderDice[j] = rand.Next(1, 7);
            
            for (int j = countDefender; j < 3; j++)
                defenderDice[j] = -10000000;
        }
        
        Array.Sort(attackerDice, (a, b) => b - a);
        Array.Sort(defenderDice, (a, b) => b - a);

        int min = countAttacker > countDefender ? countDefender : countAttacker;
        for(int j = 0;j < min; j++) {
            if(defenderDice[j] >= attackerDice[j])
                attacker.CountSoldiers -= 1;
            if(defenderDice[j] < attackerDice[j])
                defender.CountSoldiers -= 1;
        }
        // Console.WriteLine($"Atacantes: {attacker.CountSoldiers} - Defensores: {defender.CountSoldiers}");
    }

    return defender.CountSoldiers == 0;
    
}

long loop = 1000;

int attackerWins = 0;
int defenderWins = 0;

for(int i = 0; i < loop; i++) {

    Soldier defender = new(1000);
    Soldier attacker = new(1700);

    if(War(defender, attacker)) {
        attackerWins += 1;
    } else {
        defenderWins += 1;
    }
}

// int threadCount = 15;
// DateTime dt = DateTime.Now;
// Parallel.For(0, threadCount, j => {

//     for(int i = 0; i < loop/threadCount; i++) {
//         Soldier defender = new(1000);
//         Soldier attacker = new(1255);

//         if(War(defender, attacker)) {
//             attackerWins += 1;
//         } else {
//             defenderWins += 1;
//         }
//     }
// });

// var time = (DateTime.Now - dt).TotalMilliseconds;



Console.WriteLine($"Quantidade de vitórias dos Atacantes: {attackerWins}\nQuantidade de vitórias dos Defensores: {defenderWins}");
Console.WriteLine($"Porcentagem de vitória do ataque: {Math.Round((double)attackerWins / (attackerWins+defenderWins) * 100)}%\nQuantidade de batalhas: {(long)(attackerWins+defenderWins)}");
// Console.WriteLine($"Tempo de execussão: {time}");