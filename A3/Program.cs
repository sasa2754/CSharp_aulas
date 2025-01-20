using Listinha;
// Console.WriteLine("Hello, World!");

Listinha.List<int> listinhaFofa = new(20);

listinhaFofa.add(2);
listinhaFofa.add(2);

Console.WriteLine(listinhaFofa.count);
Console.WriteLine(listinhaFofa[0]);
Console.WriteLine(listinhaFofa[1]);