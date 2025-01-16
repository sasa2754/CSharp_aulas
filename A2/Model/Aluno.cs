using DataBase;

namespace Model;

public class Aluno : DataBaseObject {

    public string Nome { get; set; }

    public int Idade { get; set; }

    public int AlunoId { get; set; }


    protected override void LoadFrom(string[] data)
    {
        this.AlunoId = int.Parse(data[0]);
        this.Nome = data[1];
        this.Idade = int.Parse(data[2]);
    }

    protected override string[] SaveTo() => new string[] {
        this.AlunoId.ToString(),
        this.Nome,
        this.Idade.ToString(),
    };

}