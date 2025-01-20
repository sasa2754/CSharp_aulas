using System;
using System.Data;
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

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.AlunoId = Convert.ToInt32(data[0]);
        this.Nome = data[1].ToString();
        this.Idade = Convert.ToInt32(data[2]);
    }
    protected override string SaveToSql() => $"INSERT INTO [Aluno] VALUES ({AlunoId}, '{Nome}', {Idade})";

}