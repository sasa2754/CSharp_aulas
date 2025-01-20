using System.ComponentModel.DataAnnotations.Schema;
using Cubos;

var red = 1;
var green = 2;
var blue = 3;
var yellow = 4;

var position1 = 1;
var position2 = 1;
var position3 = 1;
var position4 = 1;

List<Cubo> listCubes = new();

Cubo cube1 = new (red, yellow, blue, yellow, yellow, green, position1);
listCubes.Add(cube1);

Cubo cube2 = new (red, yellow, yellow, blue, red, green, position2);
listCubes.Add(cube2);

Cubo cube3 = new (green, blue, green, yellow, red, blue, position3);
listCubes.Add(cube3);

Cubo cube4 = new (red, yellow, green, green, red, blue, position4);
listCubes.Add(cube4);

List<int> possib1 = new();
List<int> possib2 = new();
List<int> possib3 = new();
List<int> possib4 = new();

for(int i = 0; i < 6; i ++ ) {
    for(int j = 0; j < 4; j++) {
        possib1.Add(cube1.getPosition());
        Console.Write($"{colorsString(cube1.getPosition())}, ");
        cube1.RotateX();
    }
    cube1.Position++;
}
Console.WriteLine();


for(int i = 0; i < 6; i ++ ) {
    for(int j = 0; j < 4; j++) {
        possib2.Add(cube2.getPosition());
        Console.Write($"{colorsString(cube2.getPosition())}, ");
        cube2.RotateX();
    }
    cube2.Position++;
}
Console.WriteLine();

for(int i = 0; i < 6; i ++ ) {
    for(int j = 0; j < 4; j++) {
        possib3.Add(cube3.getPosition());
        Console.Write($"{colorsString(cube3.getPosition())}, ");
        cube3.RotateX();
    }
    cube3.Position++;
}
Console.WriteLine();
for(int i = 0; i < 6; i ++ ) {
    for(int j = 0; j < 4; j++) {
        possib4.Add(cube4.getPosition());
        Console.Write($"{colorsString(cube4.getPosition())}, ");
        cube4.RotateX();
    }
    cube4.Position++;
}
Console.WriteLine();


// for (int i = 0; i < 4; i++) {
//     for (int j = 0; j < 4; j++) {
//         possib1.Add(cube1.getPosition());
//         cube1.RotateX();
//     }
//     cube1.RotateY();
// }

// for (int i = 0; i < 4; i++) {
//     for (int j = 0; j < 4; j++) {
//         possib1.Add(cube2.getPosition());
//         cube2.RotateX();
//     }
//     cube2.RotateY();
// }

// for (int i = 0; i < 4; i++) {
//     for (int j = 0; j < 4; j++) {
//         possib1.Add(cube3.getPosition());
//         cube3.RotateX();
//     }
//     cube3.RotateY();
// }

// for (int i = 0; i < 4; i++) {
//     for (int j = 0; j < 4; j++) {
//         possib1.Add(cube4.getPosition());
//         cube4.RotateX();
//     }
//     cube4.RotateY();
// }



Console.WriteLine($"Cubo 1 Lista: {possib1.Count}");
for (int i = 0; i < possib1.Count; i++)
{
    Console.Write(possib1[i] + " ");
    if ((i + 1) % 4 == 0)
    {
        Console.WriteLine();
    }
}

Console.WriteLine($"Cubo 2 Lista: {possib2.Count}");
for (int i = 0; i < possib2.Count; i++)
{
    Console.Write(possib2[i] + " ");
    if ((i + 1) % 4 == 0)
    {
        Console.WriteLine();
    }
}

Console.WriteLine($"Cubo 3 Lista: {possib3.Count}");
for (int i = 0; i < possib3.Count; i++)
{
    Console.Write(possib3[i] + " ");
    if ((i + 1) % 4 == 0)
    {
        Console.WriteLine();
    }
}

Console.WriteLine($"Cubo 4 Lista: {possib4.Count}");
for (int i = 0; i < possib4.Count; i++)
{
    Console.Write(possib4[i] + " ");
    if ((i + 1) % 4 == 0)
    {
        Console.WriteLine();
    }
}


// Conferindo os 4 lados dos dois primeiros cubos ;-;
// bool checkSidesOne() {
//     if(cube1.Top == cube2.Top)
//         return false;
//     else if(cube1.Front == cube2.Front)
//         return false;
//     else if(cube1.Bottom == cube2.Bottom)
//         return false;
//     else if(cube1.Back == cube2.Back)
//         return false;
//     return true;
// }


// var resolvedAll = false;
// var resolvedOne = false;
// var count = 0;
// var countTurn1 = 0;
// var countTurn2 = 0;

// while (!resolvedAll) {
//     if (cube1.Position == 6)
//         cube1.Position = 1;

//     if (cube2.Position == 6)
//         cube2.Position = 1;

//     if (cube3.Position == 6)
//         cube3.Position = 1;

//     if (cube4.Position == 6)
//         cube4.Position = 1;

//     Console.WriteLine($"Contador: {count}");

//     while(!resolvedOne) {

//         if(countTurn1 <= 4) {
//             if(!checkSidesOne()) {
//                 cube1.RotateY();
//                 countTurn1++;
//                 Console.WriteLine($"count turn 1 y: {countTurn1}");
//             } else {
//                 resolvedOne = true;
//             }
//         } else if(countTurn1 > 4 && countTurn1 <= 8) {
//             if(!checkSidesOne()) {
//                 cube1.RotateX();
//                 countTurn1++;
//                 Console.WriteLine($"count turn 1 x: {countTurn1}");

//             } else {
//                 Console.WriteLine($"Resolveu!!");
//                 resolvedOne = true;
//             }

//         } else if(countTurn1 > 8 && countTurn1 <= 12) {
//             if(!checkSidesOne()) {
//                 cube1.RotateXY();
//                 countTurn1++;
//                 Console.WriteLine($"count turn 1 x: {countTurn1}");

//             } else {
//                 Console.WriteLine($"Resolveu!!");
//                 resolvedOne = true;
//             }
//         } else if(countTurn1 >= 13) {
//             if(!checkSidesOne()) {
//                 cube2.RotateY();
//                 countTurn2++;
//                 Console.WriteLine($"count turn 2 y: {countTurn2}");
//             } else {
//                 resolvedOne = true;
//             }

//         } else if(countTurn2 > 4 && countTurn2 <= 8) {
//             if(!checkSidesOne()) {
//                 cube2.RotateX();
//                 countTurn2++;
//                 Console.WriteLine($"count turn 2 x: {countTurn2}");

//             } else {
//                 Console.WriteLine($"Resolveu!!");
//                 resolvedOne = true;
//             }

//         } else if(countTurn2 > 8 && countTurn2 <= 12) {
//             if(!checkSidesOne()) {
//                 cube2.RotateXY();
//                 countTurn1++;
//                 Console.WriteLine($"count turn 1 x: {countTurn2}");

//             } else {
//                 Console.WriteLine($"Resolveu!!");
//                 resolvedOne = true;
//             }
//         }


        // if (countTurn1 < 7) {
        //     if(cube1.getPosition() == cube2.getPosition()) {
        //         cube1.RotateY();
        //         cube1.Position++;
        //         countTurn1 ++;
        //     }
        //     else {
        //         if(cube1.getPosition() != cube2.getPosition()){
        //             resolvedOne = true;
        //             break;
        //         }
        //     }
        // }

        // else {
        //     if(countTurn2 < 7) {
        //         if(cube1.getPosition() == cube2.getPosition())
        //             cube2.Position ++;
        //         countTurn2 ++;
        //     }
        //     else {
        //         Console.WriteLine("n funciona!");
        //         resolvedAll = true;
        //     }
        // }
//     }

//     Console.WriteLine($"Cubo 1: {cube1.Position}\nCubo 2: {cube2.Position}");
//     count++;
//     break;
// }


string colorsString(int color) {
    return color switch
    {
        1 => "Red",
        2 => "Green",
        3 => "Blue",
        4 => "Yellow",
        _ => "Unknown Color"
    };
}