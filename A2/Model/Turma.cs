using System;
using System.Data;
using DataBase;

namespace Model;

public class Turma : DataBaseObject {

    public string Nome { get; set; }

    public int Semestre { get; set; }

    public int TurmaId { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.TurmaId = int.Parse(data[0]);
        this.Nome = data[1];
        this.Semestre = int.Parse(data[2]);
    }

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.TurmaId = Convert.ToInt32(data[0]);
        this.Nome = (string)data[1];
        this.Semestre = Convert.ToInt32(data[2]);
    }

    protected override string[] SaveTo() => [
        this.TurmaId.ToString(),
        this.Nome,
        this.Semestre.ToString(),
    ];

    protected override string SaveToSql() => $"INSERT INTO [Turmas] VALUES ({TurmaId}, '{Nome}', '{Semestre}')";

}