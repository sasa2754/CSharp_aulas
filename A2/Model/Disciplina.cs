using System.Data;
using DataBase;

namespace Model;

public class Disciplina : DataBaseObject {

    public string Nome { get; set; }

    public string Descricao { get; set; }

    protected override void LoadFrom(string[] data) {
        this.Nome = data[0];
        this.Descricao = data[1];
    }

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.Nome = (string)data[0];
        this.Descricao = (string)data[1];
    }

    protected override string[] SaveTo() => [
        this.Nome,
        this.Descricao
    ];

    protected override string SaveToSql() => $"INSERT INTO [Disciplina] VALUES ('{Nome}', '{Descricao}')";

}