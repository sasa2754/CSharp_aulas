using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class TurmaAlunosFakeRepository : IRepository<TurmaAlunos> {
    List<TurmaAlunos> turmaAlunos = [];

    public TurmaAlunosFakeRepository() {
        var dbTurmaAlunos = DB<TurmaAlunos>.App;
        turmaAlunos = dbTurmaAlunos.All ?? new List<TurmaAlunos>();

        // turmaAlunos.Add(new () {
        //     TurmaId = 1,
        //     AlunosId = 1,
        // });
        // turmaAlunos.Add(new () {
        //     TurmaId = 1,
        //     AlunosId = 2,
        // });
        // dbTurmaAlunos.Save(turmaAlunos);
    }


    

    public List<TurmaAlunos> All => turmaAlunos;

    public void Add(TurmaAlunos obj) => this.turmaAlunos.Add(obj);
}