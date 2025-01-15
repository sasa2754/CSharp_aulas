using DataBase;

namespace Model;

public class Disciplina : DataBaseObject {

    public string Nome { get; set; }

    public string Descricao { get; set; }

    protected override void LoadFrom(string[] data) {
        this.Nome = data[0];
        this.Descricao = data[0];
    }

    protected override string[] SaveTo() => [
        this.Nome,
        this.Descricao
    ];
}