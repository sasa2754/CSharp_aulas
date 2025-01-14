using System.Collections.Generic;

namespace Model;

public class AlunoFakeRepository : IRepository<Aluno> {

    List<Aluno> alunos = [];

    public AlunoFakeRepository() {
        alunos.Add(new () {
            Nome = "Sabrina",
            Idade = 20,
        });
        alunos.Add(new () {
            Nome = "Andrey",
            Idade = 20,
        });

    }
    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);

}