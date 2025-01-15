using System.Collections.Generic;

namespace Model.Respository;

public class AlunoFakeRepository : IRepository<Aluno> {

    List<Aluno> alunos = [];

    public AlunoFakeRepository() {
        alunos.Add(new () {
            Nome = "Sabrina",
            Idade = 20,
            AlunoId = 1
        });
        alunos.Add(new () {
            Nome = "Andrey",
            Idade = 19,
            AlunoId = 2
        });

    }
    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);

}