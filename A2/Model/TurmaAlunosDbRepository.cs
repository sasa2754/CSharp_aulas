using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class TurmaAlunosDbRepository : IRepository<TurmaAlunos> {

    protected DBSqlSrv<TurmaAlunos> db;

    public TurmaAlunosDbRepository() {
        db = new DBSqlSrv<TurmaAlunos> (
            "CA-C-00652\\SQLEXPRESS",
            "SistemaEscolar"
        );
    }
    public List<TurmaAlunos> All => db.All;

    public void Add(TurmaAlunos obj)
    {
        db.Save(obj);
    }
}