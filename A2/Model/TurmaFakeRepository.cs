using System.Collections.Generic;

namespace Model.Respository;

public class TurmaFakeRepository : IRepository<Turma> {

    List<Turma> turmas = [];

    public TurmaFakeRepository() {
        turmas.Add(new () {
            Nome = "DTA 2024",
            Semestre = 3,
            TurmaId = 1
        });
    }

    public List<Turma> All => turmas;

    public void Add(Turma obj) => this.turmas.Add(obj);
}