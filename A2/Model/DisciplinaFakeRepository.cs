using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class DisciplinaFakeRepository : IRepository<Disciplina> {

    List<Disciplina> disciplinas = [];

    public DisciplinaFakeRepository() {
        var dbDisciplina = DB<Disciplina>.App;
        disciplinas = dbDisciplina.All ?? new List<Disciplina>();
        // disciplinas.Add(new(){
        //     Nome = "C#",
        //     Descricao = "Aprender C#"
        // });
        // dbDisciplina.Save(disciplinas);
    }

    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj) => this.disciplinas.Add(obj);
}