using System.Collections.Generic;
using DataBase;

namespace Model.Respository;

public class ProfessorDbRepository : IRepository<Professor> {

    protected DBSqlSrv<Professor> db;

    public ProfessorDbRepository() {
        db = new DBSqlSrv<Professor> (
            "CA-C-00652\\SQLEXPRESS",
            "SistemaEscolar"
        );
    }
    public List<Professor> All => db.All;

    public void Add(Professor obj)
    {
        db.Save(obj);
    }
}