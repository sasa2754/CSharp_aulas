using System.Collections.Generic;

namespace Model.Respository;

public class DisciplinaFakeRepository : IRepository<Disciplina> {

    List<Disciplina> disciplinas = [];

    public DisciplinaFakeRepository() {
        disciplinas.Add(new(){
            Nome = "C#",
            Descricao = "Aprender C#"
        });
    }

    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj) => this.disciplinas.Add(obj);
}