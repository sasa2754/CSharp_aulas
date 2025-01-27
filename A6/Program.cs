List<string> list = new();
list.Add("Joca");
list.Add("Luana");
list.Add("Spock");
list.Add("Dory");

List<string> list1 = new();
list1.Add("Ralph");
list1.Add("Felps");

List<string> list2 = new();
list2.Add("Urso");
list2.Add("Quico");

List<string> list3 = new();
list3.Add("Marrie");
list3.Add("Koda");
list3.Add("Romeu");
list3.Add("Amora");
list3.Add("Fifo");


Pessoa pessoa = new("Sabrina", 20, 'F', 1.69f, list);


Pessoa pessoa1 = new("Fernando", 20, 'M', 1.71f, list1);
Pessoa pessoa2 = new("Eduardo Ribeiro", 20, 'M', 1.75f, list2);
Pessoa pessoa3 = new("Kauane", 20, 'F', 1.69f, list3);

string json = pessoa.ToJson();
// Console.WriteLine(json);


string[] pecas = ["motor", "farol", "volante", "radio", "tanque"];

Carros carro = new("Ford", 2007, pecas);

// Console.WriteLine(carro.ToJson());

List<Pessoa> pessoas = new();

pessoas.Add(pessoa1);
pessoas.Add(pessoa2);
pessoas.Add(pessoa3);


Console.WriteLine("Sabrina".ToJson());

// Console.WriteLine(pessoas.ToJson());




public class Carros(string marca, int ano, string[] peca) {
    private string marca = marca;
    private int ano = ano;
    private string[] peca = peca;

    public string Marca { get => marca; set => marca = value; }
    public int Ano { get => ano; set => ano = value; }
    public string[] Peca { get => peca; set => peca = value; }
}




public class Pessoa(string name, int age, char gender, float stature, IEnumerable<string> dogNames) {
    private string name = name;
    private int age = age;
    private char gender = gender;
    private float stature = stature;
    private IEnumerable<string> dogNames = dogNames;

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
    public char Gender { get => gender; set => gender = value; }
    public float Stature { get => stature; set => stature = value; }
    public IEnumerable<string> DogNames { get => dogNames; set => dogNames = value; }
}
