using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class TurmaDbRepository : IRepository<Turma> {

    protected DBSqlSrv<Turma> db;

    public TurmaDbRepository() {
        db = new DBSqlSrv<Turma> (
            "CA-C-00652\\SQLEXPRESS",
            "SistemaEscolar"
        );
    }
    public List<Turma> All => db.All;

    public void Add(Turma obj)
    {
        db.Save(obj);
    }
}