using Enumerators;
Console.WriteLine("Hello, World!");

int[] array = [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 ];


Console.WriteLine(array.MyWhere(i => i % 2 == 0));
Console.Write("\nWhere: ");
foreach (var item in array.MyWhere(i => i % 2 == 0)){
    Console.Write($"{item} ");
}

// Console.WriteLine($"FirstOfDefault: {array.MyFirstOrDefault<int>()}");
// Console.WriteLine($"LastOrDefault: {array.MyLastOrDefault<int>()}");

// Console.Write("\nToArray: ");
// foreach (var item in array.MyToArray()){
//     Console.Write($"{item} ");
// }
// Console.Write($"\nTipo: {array.MyToArray().GetType()}\n");

// Console.Write("\nToList: ");
// foreach (var item in array.MyToList()){
//     Console.Write($"{item} ");
// }
// Console.Write($"\nTipo: {array.MyToList().GetType()}\n");


// Console.Write("\nTake: ");
// foreach (var item in array.MyTake(3)){
//     Console.Write($"{item} ");
// }

// Console.Write("\nSkip: ");
// foreach (var item in array.MySkip(3)){
//     Console.Write($"{item} ");
// }

// Console.Write("\nAppend: ");
// foreach (var item in array.MyAppend(58)){
//     Console.Write($"{item} ");
// }

// Console.Write("\nPreprend: ");
// foreach (var item in array.MyPreprend(58)){
//     Console.Write($"{item} ");
// }




// Console.WriteLine(array.MyCount());