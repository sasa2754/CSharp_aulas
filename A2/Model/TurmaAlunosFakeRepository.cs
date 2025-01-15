using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace Model.Respository;

public class TurmaAlunosFakeRepository : IRepository<TurmaAlunos> {

    IRepository<Aluno> alunoRepo = new AlunoFakeRepository();
    IRepository<Turma> turmaRepo = new TurmaFakeRepository();

    List<TurmaAlunos> turmaAlunos = [];

    public TurmaAlunosFakeRepository() {
        turmaAlunos.Add(new () {
            TurmaId = 1,
            AlunosId = 1,
        });
        turmaAlunos.Add(new () {
            TurmaId = 1,
            AlunosId = 2,
        });
    }


    

    public List<TurmaAlunos> All => turmaAlunos;

    public void Add(TurmaAlunos obj) => this.turmaAlunos.Add(obj);
}