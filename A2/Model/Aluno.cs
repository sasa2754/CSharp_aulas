using DataBase;

namespace Model;

public class Aluno : DataBaseObject {

    public string Nome { get; set; }

    public int Idade { get; set; }

    public int AlunoId { get; set; }


    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.Idade = int.Parse(data[1]);
        this.AlunoId = int.Parse(data[1]);
    }

    protected override string[] SaveTo() => new string[] {
        this.Nome,
        this.Idade.ToString()
    };

}