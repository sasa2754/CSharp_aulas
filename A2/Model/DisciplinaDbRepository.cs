using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class DisciplinaDbRepository : IRepository<Disciplina> {

    protected DBSqlSrv<Disciplina> db;

    public DisciplinaDbRepository() {
        db = new DBSqlSrv<Disciplina> (
            "CA-C-00652\\SQLEXPRESS",
            "SistemaEscolar"
        );
    }
    public List<Disciplina> All => db.All;

    public void Add(Disciplina obj)
    {
        db.Save(obj);
    }
}