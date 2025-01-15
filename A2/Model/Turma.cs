using DataBase;

namespace Model;

public class Turma : DataBaseObject {

    public string Nome { get; set; }

    public int Semestre { get; set; }

    public int TurmaId { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.Semestre = int.Parse(data[1]);
        this.TurmaId = int.Parse(data[2]);
    }

    protected override string[] SaveTo() => [
        this.Nome,
        this.Semestre.ToString()
    ];
}