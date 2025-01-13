public class Pessoa(string name, int? age)
{
    private string name = name;
    public string Name { get => name; set => name = value; }

    private int? age = age;
    public int? Age { get => age; set => age = value; }


    public static int getFutureAge(int year) {
        
        return 0;
    }


}