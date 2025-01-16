using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class ProfessorFakeRepository : IRepository<Professor> {
    List<Professor> professores = [];

    public ProfessorFakeRepository() {
        var dbProfessor = DB<Professor>.App;
        professores = dbProfessor.All ?? new List<Professor>();

        // professores.Add(new(){
        //     Nome = "Sei lá",
        //     Formacao = "Não importa"
        // });
        // dbProfessor.Save(professores);
    }

    public List<Professor> All => professores;
    public void Add(Professor obj) => this.professores.Add(obj); 
}