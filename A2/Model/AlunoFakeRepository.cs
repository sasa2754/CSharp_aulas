using System.Collections.Generic;
using DataBase;


namespace Model.Respository;

public class AlunoFakeRepository : IRepository<Aluno> {

    List<Aluno> alunos = [];

    public AlunoFakeRepository() {
        var dbAluno = DB<Aluno>.App;
        alunos = dbAluno.All ?? new List<Aluno>();
    // var alunos = dbAluno.All;
        // alunos.Add(new () {
        //     Nome = "Sabrina",
        //     Idade = 20,
        //     AlunoId = 1
        // });
        // alunos.Add(new () {
        //     Nome = "Andrey",
        //     Idade = 19,
        //     AlunoId = 2
        // });
        // dbAluno.Save(alunos);
    }
    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);

}