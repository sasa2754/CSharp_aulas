using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class TurmaFakeRepository : IRepository<Turma> {

    List<Turma> turmas = [];

    public TurmaFakeRepository() {
        var dbTurma = DB<Turma>.App;
        turmas = dbTurma.All ?? new List<Turma>();
        // turmas.Add(new () {
        //     Nome = "DTA 2024",
        //     Semestre = 3,
        //     TurmaId = 1
        // });
        // dbTurma.Save(turmas);
    }

    public List<Turma> All => turmas;

    public void Add(Turma obj) => this.turmas.Add(obj);
}