using System.Collections.Generic;

namespace Model.Respository;

public class ProfessorFakeRepository : IRepository<Professor> {
    List<Professor> professores = [];

    public ProfessorFakeRepository() {
        professores.Add(new(){
            Nome = "Sei lá",
            Formacao = "Não importa"
        });
    }

    public List<Professor> All => professores;
    public void Add(Professor obj) => this.professores.Add(obj); 
}