using System;
using System.Data;
using DataBase;

namespace Model;

public class TurmaAlunos : DataBaseObject {
    public int TurmaId { get; set; }
    public int AlunosId { get; set; }

    public Turma turma { get; set; }

    public Aluno aluno { get; set; }

    protected override void LoadFrom(string[] data) {
        this.TurmaId = int.Parse(data[0]);
        this.AlunosId = int.Parse(data[1]);
    }

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.TurmaId = Convert.ToInt32(data[0]);
        this.AlunosId = Convert.ToInt32(data[1]);
    }

    protected override string[] SaveTo() => [
        this.TurmaId.ToString(),
        this.AlunosId.ToString()
    ];

    protected override string SaveToSql() => $"INSERT INTO [TurmaAlunos] VALUES ({AlunosId}, {TurmaId})";

}